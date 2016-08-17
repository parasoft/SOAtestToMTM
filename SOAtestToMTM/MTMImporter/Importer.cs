using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace MTMImporter
{
    class Importer
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

        public void Import(string teamProject, DATestRun testRun)
        {
            var ims = tpc.GetService<IIdentityManagementService>();
            var tms = tpc.GetService<ITestManagementService>();
            var project = tms.GetTeamProject(teamProject);
            var configuration = GetTestConfiguration(project, testRun.ConfigurationName);
            var testPlan = GetTestPlan(project, testRun.TestPlanId);

            var run = testPlan.CreateTestRun(true);

            if (testRun.Title != null)
            {
                run.Title = testRun.Title;
            }

            if (testRun.DateStarted != null)
            {
                run.DateStarted = DateTime.Parse(testRun.DateStarted);
            }

            if (testRun.OwnerName != null)
            {
                TeamFoundationIdentity identity;
                if (TryGetIdentity(ims, testRun.OwnerName, out identity))
                {
                    run.Owner = identity;
                }
            }

            if (testRun.BuildNumber != null)
            {
                run.BuildNumber = testRun.BuildNumber;

                IBuildDetail buildDetail;
                if (TryGetBuildDetail(teamProject, testRun.BuildNumber, out buildDetail))
                {
                    run.BuildUri = buildDetail.Uri;
                }
            }

            if (testRun.TestEnvironment != null)
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
                foreach (var testCase in testRun.TestCases)
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
                foreach (var testCase in testRun.TestCases)
                {
                    if (testCase.TestCaseId.Equals(result.TestCaseId))
                    {
                        if (testCase.DateStarted != null)
                        {
                            result.DateStarted = DateTime.Parse(testCase.DateStarted);
                        }

                        if (testCase.DateCompleted != null)
                        {
                            result.DateCompleted = DateTime.Parse(testCase.DateCompleted);
                        }

                        if (result.DateStarted != null && result.DateCompleted != null)
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
                        }

                        if (testCase.ErrorMessage != null)
                        {
                            result.ErrorMessage = testCase.ErrorMessage;
                        }

                        if (testCase.Comment != null)
                        {
                            result.Comment = testCase.Comment;
                        }

                        if (testCase.OwnerName != null)
                        {
                            TeamFoundationIdentity identity;
                            if (TryGetIdentity(ims, testCase.OwnerName, out identity))
                            {
                                result.Owner = identity;
                            }
                        }

                        if (testCase.RunByName != null)
                        {
                            TeamFoundationIdentity identity;
                            if (TryGetIdentity(ims, testCase.RunByName, out identity))
                            {
                                result.RunBy = identity;
                            }
                        }

                        if (testCase.FailureType != null)
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

                        if (testCase.ResolutionState != null)
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
            if (testRun.Comment != null)
            {
                run.Comment = testRun.Comment;
            }

            if (testRun.DateCompleted != null)
            {
                run.DateCompleted = DateTime.Parse(testRun.DateCompleted);
            }

            run.State = TestRunState.Completed;
            run.Save();
        }

        ITestPlan GetTestPlan(ITestManagementTeamProject project, int testPlanId)
        {
            var testPlan = project.TestPlans.Find(testPlanId);
            if (testPlan == null)
            {
                string message = String.Format("Test plan '{0}' does not exist in team project '{1}'", testPlanId, project.TeamProjectName);
                throw new ImportException(message);
            }
            return testPlan;
        }

        ITestConfiguration GetTestConfiguration(ITestManagementTeamProject project, string configurationName)
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

        bool TryGetTestEnvironment(ITestManagementTeamProject project, string environmentName, out ITestEnvironment testEnvironment)
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

        bool TryGetBuildDetail(string teamProject, string buildNumber, out IBuildDetail buildDetail)
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

        bool TryGetIdentity(IIdentityManagementService ims, string accountName, out TeamFoundationIdentity identity)
        {

            if (!identities.TryGetValue(accountName, out identity))
            {
                identity = ims.ReadIdentity(IdentitySearchFactor.AccountName, accountName, MembershipQuery.None, ReadIdentityOptions.None);
            }
            return identity != null;
        }

        bool TryGetFailureTypeId(IEnumerable<ITestFailureType> failureTypes, string name, out int id)
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

        bool TryGetResolutionStateId(IEnumerable<ITestResolutionState> resolutionStates, string name, out int id)
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

        static void Main(string[] args)
        {
            try
            {
                var uri = args[0];
                var username = args[1];
                var password = args[2];
                var domain = args[3];
                var teamProject = args[4];
                var testRun = LoadTestRunFile(args[5]);
                var importer = new Importer(uri, username, password, domain);
                importer.Import(teamProject, testRun);
            }
            catch (ImportException e)
            {
                Error(e);
            }
            catch (TeamFoundationServerException e)
            {
                Error(e);
            }
        }

        static DATestRun LoadTestRunFile(string file)
        {
            using (FileStream stream = File.Open(file, FileMode.Open))
            {
                var serializer = new DataContractJsonSerializer(typeof(DATestRun));
                return serializer.ReadObject(stream) as DATestRun;
            }
        }

        static void Error(Exception e)
        {
            Console.Error.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }

    [DataContract]
    internal class DATestCase
    {
        [DataMember(Name = "testCaseId")]
        public int TestCaseId { get; set; }

        [DataMember(Name = "dateStarted")]
        public string DateStarted { get; set; }

        [DataMember(Name = "dateCompleted")]
        public string DateCompleted { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "errorMessage")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "priority")]
        public int? Priority { get; set; }

        [DataMember(Name = "ownerName")]
        public string OwnerName { get; set; }

        [DataMember(Name = "runByName")]
        public string RunByName { get; set; }

        [DataMember(Name = "failureType")]
        public string FailureType { get; set; }

        [DataMember(Name = "resolutionState")]
        public string ResolutionState { get; set; }
    }

    [DataContract]
    internal class DATestRun
    {

        [DataMember(Name = "testPlanId")]
        public int TestPlanId { get; set; }

        [DataMember(Name = "configurationName")]
        public string ConfigurationName { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "dateStarted")]
        public string DateStarted { get; set; }

        [DataMember(Name = "dateCompleted")]
        public string DateCompleted { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "testEnvironment")]
        public string TestEnvironment { get; set; }

        [DataMember(Name = "buildNumber")]
        public string BuildNumber { get; set; }

        [DataMember(Name = "ownerName")]
        public string OwnerName { get; set; }

        [DataMember(Name = "testCases")]
        public List<DATestCase> TestCases { get; set; }
    }

    internal class ImportException : Exception
    {
        public ImportException() : base() { }
        public ImportException(string message) : base(message) { }
        public ImportException(string message, Exception cause) : base(message, cause) { }
    }
}