using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace SOAtestToMTM
{
    [TestClass]
    public class ImporterTest
    {
        [TestMethod]
        public void TestImporterConvertToTestRun()
        {
            Parser parser = new Parser();
            string filePath = @"..\..\TestData\report.xml";
            ResultsSession rs = parser.parse(filePath);
            List<TFSTestRun> testRuns = Importer.convertResultToTestRun(rs);
            Assert.AreEqual(testRuns.Count, 1);
            
        }
    }
}
