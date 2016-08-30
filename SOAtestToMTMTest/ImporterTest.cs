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
            string filePath = @"..\..\TestData\report.xml";
            ResultsSession rs = Parser.Parse(filePath);
            List<TFSTestRun> testRuns = Importer.ConvertResultToTestRun(rs);
            Assert.AreEqual(testRuns.Count, 1);

        }
    }
}
