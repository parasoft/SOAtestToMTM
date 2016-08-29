
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAtestToMTM
{
    public class TFSTestRun
    {
        public int TestPlanId { get; set; }
        public string ConfigurationName { get; set; }
        public string Title { get; set; }
        public System.DateTime DateStarted { get; set; }
        public System.DateTime DateCompleted { get; set; }
        public string Comment { get; set; }
        public string TestEnvironment { get; set; }
        public string BuildNumber { get; set; }
        public string OwnerName { get; set; }
        public Dictionary<int, TFSTestCase> TestCases { get; set; }

        /// <summary>
        /// Add a test step to existing test case, and update its status/time
        /// </summary>
        /// <param name="testCaseId">test case id to add to</param>
        /// <param name="test">ResultsSession Test</param>
        public void AddTestCase(int testCaseId, Test test)
        {
            if (TestCases == null)
            {
                TestCases = new Dictionary<int, TFSTestCase>();
            }

            TFSTestCase testCase = null;
            DateTime endTime = test.StartTime.Add(test.Time);
            if (!TestCases.TryGetValue(testCaseId, out testCase))
            {
                testCase = new TFSTestCase();
                testCase.Status = test.Status;
                testCase.TestCaseId = testCaseId;
                testCase.DateStarted = test.StartTime;
                testCase.DateCompleted = endTime;
                int type = 0;
                StringBuilder sb = new StringBuilder();
                foreach (FuncViol error in test.FuncViol)
                {
                    if (testCase.ErrorMessage == null)
                    {
                        testCase.ErrorMessage = error.Msg;
                    }
                    sb.AppendLine(error.Msg);
                    if (type < error.Sev)
                    {
                        type = error.Sev;
                    }
                }
                switch (type)
                {
                    case 1:
                        testCase.FailureType = "Regression";
                        testCase.ResolutionState = "Product issue";
                        break;
                    case 2:
                        testCase.FailureType = "New Issue";
                        testCase.ResolutionState = "Test issue";
                        break;
                    case 3:
                        testCase.FailureType = "Unknown";
                        testCase.ResolutionState = "Needs investigation";
                        break;
                    default:
                        //do nothing
                        break;
                }
                testCase.Comment = sb.ToString();
                TestCases.Add(testCase.TestCaseId, testCase);
            }
            else
            {
                if (testCase.Status < test.Status)
                {
                    testCase.Status = test.Status;
                }

                if (DateTime.Compare(testCase.DateStarted, test.StartTime) > 0)
                {
                    testCase.DateStarted = test.StartTime;
                }

                if (DateTime.Compare(testCase.DateCompleted, endTime) < 0)
                {
                    testCase.DateCompleted = endTime;
                }

                if (DateTime.Compare(DateStarted, test.StartTime) > 0)
                {
                    DateStarted = test.StartTime;
                }

                if (DateTime.Compare(DateCompleted, endTime) < 0)
                {
                    DateCompleted = endTime;
                }

            }


        }
    }

    public class TFSTestCase
    {
        public int TestCaseId { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Comment { get; set; }
        public int? Priority { get; set; }
        public string OwnerName { get; set; }
        public string RunByName { get; set; }
        public string FailureType { get; set; }
        public string ResolutionState { get; set; }
    }

}

