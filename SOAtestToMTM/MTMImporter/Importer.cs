using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.TestManagement.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace SOAtestToMTM
{
    public class Importer
    {
        private readonly TfsTeamProjectCollection tpc;
        private readonly IDictionary<string, TeamFoundationIdentity> identities;

        public Importer(string tfsUri, string username, string password, string domain)
        {
            var netCred = new NetworkCredential(username, password, domain);
            var windowsCred = new WindowsCredential(netCred);
            var tfsCred = new TfsClientCredentials(windowsCred);
            tfsCred.AllowInteractive = false;

            var uri = new Uri(tfsUri);
            tpc = new TfsTeamProjectCollection(uri, tfsCred);
            tpc.EnsureAuthenticated();

            identities = new Dictionary<string, TeamFoundationIdentity>();
        }

        public void Import(string teamProject, List<TFSTestRun> testRuns)
        {
            var ims = tpc.GetService<IIdentityManagementService>();
            var tms = tpc.GetService<ITestManagementService>();
            var project = tms.GetTeamProject(teamProject);
            foreach (TFSTestRun testRun in testRuns)
            {
                var configuration = GetTestConfiguration(project, testRun.ConfigurationName);
                var testPlan = GetTestPlan(project, testRun.TestPlanId);

                var run = testPlan.CreateTestRun(true);
                if (!string.IsNullOrEmpty(testRun.Title))
                {
                    run.Title = testRun.Title;
                }

                if (testRun.DateStarted != default(DateTime))
                {
                    run.DateStarted = testRun.DateStarted;
                }

                if (!string.IsNullOrEmpty(testRun.OwnerName))
                {
                    TeamFoundationIdentity identity;
                    if (TryGetIdentity(ims, testRun.OwnerName, out identity))
                    {
                        run.Owner = identity;
                    }
                }

                if (!string.IsNullOrEmpty(testRun.BuildNumber))
                {
                    run.BuildNumber = testRun.BuildNumber;

                    IBuildDetail buildDetail;
                    if (TryGetBuildDetail(teamProject, testRun.BuildNumber, out buildDetail))
                    {
                        run.BuildUri = buildDetail.Uri;
                    }
                }

                if (!string.IsNullOrEmpty(testRun.TestEnvironment))
                {
                    ITestEnvironment environment;
                    if (TryGetTestEnvironment(project, testRun.TestEnvironment, out environment))
                    {
                        run.TestEnvironmentId = environment.Id;
                    }
                }

                // Add all the associated test points.
                var testPointQuery = String.Format("SELECT * FROM TestPoint WHERE ConfigurationId = '{0}'", configuration.Id);
                foreach (var testPoint in testPlan.QueryTestPoints(testPointQuery))
                {
                    foreach (var testCase in testRun.TestCases.Values)
                    {
                        if (testCase.TestCaseId.Equals(testPoint.TestCaseId))
                        {
                            run.AddTestPoint(testPoint, null);
                            break;
                        }
                    }
                }

                // Save so the test results can be created.
                run.Save();

                var failureTypes = project.TestFailureTypes.Query();
                var resolutionStates = project.TestResolutionStates.Query();

                // Configure the test results.
                foreach (var result in run.QueryResults())
                {
                    foreach (var testCase in testRun.TestCases.Values)
                    {
                        if (testCase.TestCaseId.Equals(result.TestCaseId))
                        {
                            if (testCase.DateStarted != default(DateTime))
                            {
                                result.DateStarted = testCase.DateStarted;
                            }

                            if (testCase.DateCompleted != default(DateTime))
                            {
                                result.DateCompleted = testCase.DateCompleted;
                            }

                            if (result.DateStarted != default(DateTime) && result.DateCompleted != default(DateTime))
                            {
                                result.Duration = result.DateCompleted - result.DateStarted;
                            }

                            switch (testCase.Status)
                            {
                                case 0:
                                    result.Outcome = TestOutcome.Passed;
                                    result.State = TestResultState.Completed;
                                    break;
                                case 1:
                                    result.Outcome = TestOutcome.Failed;
                                    result.State = TestResultState.Completed;
                                    break;
                                case 2:
                                    result.Outcome = TestOutcome.Inconclusive;
                                    result.State = TestResultState.Unspecified;
                                    break;
                                default:
                                    //do nothing
                                    break;
                            }

                            if (!string.IsNullOrEmpty(testCase.ErrorMessage))
                            {
                                result.ErrorMessage = testCase.ErrorMessage;
                            }

                            if (!string.IsNullOrEmpty(testCase.Comment))
                            {
                                result.Comment = testCase.Comment;
                            }

                            if (!string.IsNullOrEmpty(testCase.OwnerName))
                            {
                                TeamFoundationIdentity identity;
                                if (TryGetIdentity(ims, testCase.OwnerName, out identity))
                                {
                                    result.Owner = identity;
                                }
                            }

                            if (!string.IsNullOrEmpty(testCase.RunByName))
                            {
                                TeamFoundationIdentity identity;
                                if (TryGetIdentity(ims, testCase.RunByName, out identity))
                                {
                                    result.RunBy = identity;
                                }
                            }

                            if (!string.IsNullOrEmpty(testCase.FailureType))
                            {
                                var id = -1;
                                if (TryGetFailureTypeId(failureTypes, testCase.FailureType, out id))
                                {
                                    result.FailureTypeId = id;
                                }

                            }

                            if (testCase.Priority.HasValue)
                            {
                                result.Priority = testCase.Priority.Value;
                            }

                            if (!string.IsNullOrEmpty(testCase.ResolutionState))
                            {
                                var id = -1;
                                if (TryGetResolutionStateId(resolutionStates, testCase.ResolutionState, out id))
                                {
                                    result.ResolutionStateId = id;
                                }
                            }
                        }
                    }

                    // Save the results.
                    result.Save();
                }

                // Refresh the run and set completion time and state.
                run.Refresh();

                // Comment can only be added after first save.
                if (string.IsNullOrEmpty(testRun.Comment))
                {
                    run.Comment = testRun.Comment;
                }

                if (testRun.DateCompleted != default(DateTime))
                {
                    run.DateCompleted = testRun.DateCompleted;
                }

                run.State = TestRunState.Completed;
                run.Save();
            }

        }

        private ITestPlan GetTestPlan(ITestManagementTeamProject project, int testPlanId)
        {
            var testPlan = project.TestPlans.Find(testPlanId);
            if (testPlan == null)
            {
                string message = String.Format("Test plan '{0}' does not exist in team project '{1}'", testPlanId, project.TeamProjectName);
                throw new ImportException(message);
            }
            return testPlan;
        }

        private ITestConfiguration GetTestConfiguration(ITestManagementTeamProject project, string configurationName)
        {
            var configQuery = String.Format("SELECT * FROM TestConfiguration WHERE Name = '{0}'", configurationName);
            var configs = project.TestConfigurations.Query(configQuery);
            if (configs.Count <= 0)
            {
                string message = String.Format("Unable to find test configuration '{0}' in team project '{1}'", configurationName, project.TeamProjectName);
                throw new ImportException(message);
            }
            return configs[0];
        }

        private bool TryGetTestEnvironment(ITestManagementTeamProject project, string environmentName, out ITestEnvironment testEnvironment)
        {
            foreach (var environment in project.TestEnvironments.Query())
            {
                if (environment.DisplayName.Equals(environmentName))
                {
                    testEnvironment = environment;
                    return true;
                }
            }
            testEnvironment = null;
            return false;
        }

        private bool TryGetBuildDetail(string teamProject, string buildNumber, out IBuildDetail buildDetail)
        {
            var buildServer = tpc.GetService<IBuildServer>();
            if (buildServer != null)
            {
                var buildQuery = buildServer.CreateBuildDetailSpec(teamProject);
                buildQuery.BuildNumber = buildNumber;

                var builds = buildServer.QueryBuilds(buildQuery).Builds;
                if (builds.Length > 0)
                {
                    buildDetail = builds[0];
                    return true;
                }
            }

            buildDetail = null;
            return false;
        }

        private bool TryGetIdentity(IIdentityManagementService ims, string accountName, out TeamFoundationIdentity identity)
        {

            if (!identities.TryGetValue(accountName, out identity))
            {
                identity = ims.ReadIdentity(IdentitySearchFactor.AccountName, accountName, MembershipQuery.None, ReadIdentityOptions.None);
            }
            return identity != null;
        }

        private bool TryGetFailureTypeId(IEnumerable<ITestFailureType> failureTypes, string name, out int id)
        {
            foreach (var failureType in failureTypes)
            {
                if (failureType.Name.Equals(name))
                {
                    id = failureType.Id;
                    return true;
                }
            }
            id = -1;
            return false;
        }

        private bool TryGetResolutionStateId(IEnumerable<ITestResolutionState> resolutionStates, string name, out int id)
        {
            foreach (var resolutionState in resolutionStates)
            {
                if (resolutionState.Name.Equals(name))
                {
                    id = resolutionState.Id;
                    return true;
                }
            }
            id = -1;
            return false;
        }

        public static void Main(string[] args)
        {
            try
            {
                validateArguments(args);
                var uri = args[0];
                var username = args[1];
                var password = args[2];
                var domain = args[3];
                var teamProject = args[4];
                Parser parser = new Parser();
                var resultsSession = parser.parse(args[5]);
                var testRun = convertResultToTestRun(resultsSession);
                var importer = new Importer(uri, username, password, domain);
                importer.Import(teamProject, testRun);
            }
            catch (FileNotFoundException e)
            {
                Error("SOAtest report not found, " + args[5] + " does not exist");
            }
            catch (ImportException e)
            {
                Error(e.Message);
            }
            catch (TeamFoundationServerException e)
            {
                Error(e.Message);
            }
            catch (System.Xml.XmlException e)
            {
                Error(e.Message);
            }
            catch(System.UriFormatException e)
            {
                Error("Invalid TFS Uri provided: " + args[0]);
            }
            finally
            {
                Console.WriteLine("Import completed");
            }
        }

        private static void validateArguments(string[] args)
        {
            if (args.Length < 6)
            {
                throw new ImportException("There are missing required parameters. The executable expects the following arguments:" + Environment.NewLine + "MTMImporter.exe <TFS uri> <TFS username> <TFS password> <TFS domain> <TFS Project> <path to SOAtest report.xml>");
            }
        }

        public static List<TFSTestRun> convertResultToTestRun(ResultsSession results)
        {
            if (results == null)
            {
                throw new ImportException("Error parsing report.xml, no results session is found.");
            }

            Dictionary<int, TFSTestRun> testRuns = new Dictionary<int, TFSTestRun>();
            //loop over tests to find test plans and test cases
            foreach (Test test in results.TestCases.Values)
            {
                HashSet<int> testPlanIds = new HashSet<int>();
                HashSet<int> testCaseIds = new HashSet<int>();
                foreach (TestAssoc assoc in test.Assoc)
                {
                    //tests with tag "req" are plans, and tests with "pr" are test cases
                    switch (assoc.Tag)
                    {
                        case "req":
                            testPlanIds.Add(assoc.Id);
                            break;
                        case "pr":
                            testCaseIds.Add(assoc.Id);
                            break;
                        default:
                            //this example only works with req and pr, otherwise do nothing
                            break;
                    }
                }

                //generate plan/testcase mapping
                foreach (int testPlanId in testPlanIds)
                {
                    TFSTestRun testRun = null;
                    //if there is no existing test plan id, create a new test run
                    if (!testRuns.TryGetValue(testPlanId, out testRun))
                    {
                        testRun = new TFSTestRun();
                        testRun.BuildNumber = results.BuildId;
                        //append comment to indicate run is auto imported.
                        testRun.Comment = "This test run was imported via SOAtestToMTM example";
                        //append title to indicate run is from SOAtest
                        testRun.Title = "SOAtest Test Run";
                        testRun.TestEnvironment = results.Tag;
                        testRun.ConfigurationName = results.Config;
                        testRun.DateStarted = results.Time;
                        testRun.OwnerName = results.User;
                        testRun.TestPlanId = testPlanId;
                        testRun.DateStarted = test.StartTime;
                        testRun.DateCompleted = test.StartTime.Add(test.Time);
                        testRuns.Add(testPlanId, testRun);
                    }


                    foreach (int testCaseId in testCaseIds)
                    {
                        //add test case to each associated test runs and update its test duration
                        testRun.AddTestCase(testCaseId, test);
                    }
                }


            }

            return new List<TFSTestRun>(testRuns.Values);
        }

        private static void Error(string message)
        {
            Console.Error.WriteLine(message);
            Environment.Exit(1);
        }


        [Serializable]
        private sealed class ImportException : Exception
        {
            public ImportException() : base() { }
            public ImportException(string message) : base(message) { }
            public ImportException(string message, Exception cause) : base(message, cause) { }

        }
    }
}