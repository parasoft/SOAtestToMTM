using System;
using System.Collections.Generic;

namespace SOAtestToMTM
{
    public class ResultsSession
    {
        public string User { get; set; }
        public string Config { get; set; }
        public string BuildId { get; set; }
        public string Project { get; set; }
        public string Tag { get; set; }
        public DateTime Time { get; set; }
        public Dictionary<string, Test> TestCases { get; set; }
    }

    public class Test
    {
        public List<TestAssoc> Assoc { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Time { get; set; }
        public List<FuncViol> FuncViol { get; set; }
    }


    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TestAssoc
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }

    /// <remarks/>
    public class FuncViol
    {
        public int Cat { get; set; }
        public string TaskType { get; set; }
        public string ViolationDetails { get; set; }
        public string Msg { get; set; }
        public string TestCaseId { get; set; }
        public int Sev { get; set; }
    }



}
