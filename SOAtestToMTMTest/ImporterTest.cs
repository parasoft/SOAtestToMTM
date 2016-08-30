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

        [TestMethod]
        public void TestSimpleCipher()
        {
            string password = "password";
            string encrypted = SimpleCipher.Encrypt(password);
            Assert.AreEqual(password, SimpleCipher.Decrypt(encrypted));

        }

    }
}
