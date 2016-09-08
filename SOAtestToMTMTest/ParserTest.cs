using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SOAtestToMTM
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void TestParserPositive()
        {
            string filePath = @"..\..\TestData\report.xml";
            ResultsSession rs = Parser.Parse(filePath);
            Assert.AreEqual<String>(rs.Project, "Default Project");
            Assert.AreEqual<String>(rs.Config, "Example Configuration");
            Assert.AreEqual<String>(rs.Tag, "Example Configuration");
            Assert.AreEqual<String>(rs.User, "testUser");
            Assert.AreEqual(rs.BuildId, "build-2016-08-18 15:17:02");
            DateTime time = DateTime.Parse("2016-08-18T15:17:02-07:00");
            Assert.AreEqual<DateTime>(rs.Time, time);
            Assert.AreEqual(rs.TestCases.Count, 16);
            Assert.AreEqual(rs.TestCases["wk:///test/Premera.tst#0000000000#0000000002#0000000006"].Assoc.Count, 2);
            Assert.AreEqual(rs.TestCases["wk:///test/Premera.tst#0000000000#0000000002#0000000006"].Assoc[0].Id, 308);
            Assert.AreEqual(rs.TestCases["wk:///test/Premera.tst#0000000000#0000000002#0000000006"].FuncViol.Count, 1);
            Assert.AreEqual(rs.TestCases["wk:///test/Premera.tst#0000000000#0000000002#0000000006"].FuncViol[0].Sev, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestParserFileNotExist()
        {
            string filePath = @"..\..\TestData\report1.xml";
            ResultsSession rs = Parser.Parse(filePath);
        }

    }
}
