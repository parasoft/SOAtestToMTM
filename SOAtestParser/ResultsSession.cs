using System;
using System.Collections.Generic;

    namespace SOAtestToMTM{
        public class ResultsSession
    {
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        } 
        /// <remarks/>
        private string config;

        public string Config
        {
            get { return config; }
            set { config = value; }
        }

        /// <remarks/>
        private string buildId;

        public string BuildId
        {
            get { return buildId; }
            set { buildId = value; }
        }

        /// <remarks/>
        private string project;

        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        /// <remarks/>
        private string tag;

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        /// <remarks/>
        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private Dictionary<string, Test> testCases;

        public Dictionary<string, Test> TestCases
        {
            get { return testCases; }
            set { testCases = value; }
        }

    }


    /// <remarks/>
    public class Test
    {

        /// <remarks/>
        private List<TestAssoc> assoc;

        public List<TestAssoc> Assoc
        {
            get { return assoc; }
            set { assoc = value; }
        }

        /// <remarks/>

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <remarks/>

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <remarks/>

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <remarks/>

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <remarks/>

        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        private List<FuncViol> funcViol;

        public List<FuncViol> FuncViol
        {
            get { return funcViol; }
            set { funcViol = value; }
        }
    

    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TestAssoc
    {


        /// <remarks/>

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <remarks/>

        private string tag;

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

    }

    /// <remarks/>
    public class FuncViol
    {


        /// <remarks/>

        private int cat;

        public int Cat
        {
            get { return cat; }
            set { cat = value; }
        }


        /// <remarks/>

        private string taskType;

        public string TaskType
        {
            get { return taskType; }
            set { taskType = value; }
        }


        /// <remarks/>

        private string violationDetails;

        public string ViolationDetails
        {
            get { return violationDetails; }
            set { violationDetails = value; }
        }

        /// <remarks/>

        private string msg;

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }


        /// <remarks/>

        private string testCaseId;

        public string TestCaseId
        {
            get { return testCaseId; }
            set { testCaseId = value; }
        }

        private int sev;

        public int Sev
        {
            get { return sev; }
            set { sev = value; }
        }
        


    }



    }
