
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAtestToMTM
{
    public class TFSTestRun
    {
        private int testPlanId;

        public int TestPlanId
        {
            get { return testPlanId; }
            set { testPlanId = value; }
        }

        private string configurationName;

        public string ConfigurationName
        {
            get { return configurationName; }
            set { configurationName = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private System.DateTime dateStarted;

        public System.DateTime DateStarted
        {
            get { return dateStarted; }
            set { dateStarted = value; }
        }

        private System.DateTime dateCompleted;

        public System.DateTime DateCompleted
        {
            get { return dateCompleted; }
            set { dateCompleted = value; }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private string testEnvironment;

        public string TestEnvironment
        {
            get { return testEnvironment; }
            set { testEnvironment = value; }
        }

        private string buildNumber;

        public string BuildNumber
        {
            get { return buildNumber; }
            set { buildNumber = value; }
        }

        private string ownerName;

        public string OwnerName
        {
            get { return ownerName; }
            set { ownerName = value; }
        }

        private Dictionary<int, TFSTestCase> testCases;

        public Dictionary<int, TFSTestCase> TestCases
        {
            get { return testCases; }
            set { testCases = value; }
        }

        /// <summary>
        /// Add a test step to existing test case, and update its status/time
        /// </summary>
        /// <param name="testCaseId">test case id to add to</param>
        /// <param name="test">ResultsSession Test</param>
        public void AddTestCase(int testCaseId, Test test)
        {
            if (testCases == null)
            {
                testCases = new Dictionary<int, TFSTestCase>();
            }

            TFSTestCase testCase = null;
            DateTime endTime = test.StartTime.Add(test.Time);
            if (!testCases.TryGetValue(testCaseId, out testCase))
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
                testCases.Add(testCase.TestCaseId, testCase);
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

                if (DateTime.Compare(dateStarted, test.StartTime) > 0)
                {
                    dateStarted = test.StartTime;
                }

                if (DateTime.Compare(dateCompleted, endTime) < 0)
                {
                    dateCompleted = endTime;
                }

            }


        }
    }

    public class TFSTestCase
    {
        private int testCaseId;

        public int TestCaseId
        {
            get { return testCaseId; }
            set { testCaseId = value; }
        }

        private DateTime dateStarted;

        public DateTime DateStarted
        {
            get { return dateStarted; }
            set { dateStarted = value; }
        }

        private DateTime dateCompleted;

        public DateTime DateCompleted
        {
            get { return dateCompleted; }
            set { dateCompleted = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        public string Comment { get; set; }

        public int? Priority { get; set; }

        public string OwnerName { get; set; }

        public string RunByName { get; set; }

        public string FailureType { get; set; }

        public string ResolutionState { get; set; }
    }

}

