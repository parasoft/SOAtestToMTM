using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SOAtestToMTM
{
    public class Parser
    {
        /// <summary>
        /// parse a SOAtest report.xml file into ResultsSession object
        /// </summary>
        /// <param name="pathToXmlFile">full path to file</param>
        /// <returns>ResultsSession Object</returns>
        public ResultsSession Parse(string pathToXmlFile)
        {
            string filePath = @pathToXmlFile;
            if (File.Exists(filePath))
            {
                ResultsSession results = new ResultsSession();
                using (XmlReader reader = XmlReader.Create(filePath))
                {

                    reader.ReadToFollowing("ResultsSession");
                    results.BuildId = reader.GetAttribute("buildId");
                    results.Project = reader.GetAttribute("project");
                    results.Tag = reader.GetAttribute("tag");
                    results.Time = DateTime.Parse(reader.GetAttribute("time"));
                    results.TestCases = new Dictionary<string, Test>();
                    reader.ReadToDescendant("TestConfig");
                    results.Config = reader.GetAttribute("name");
                    results.User = reader.GetAttribute("user");
                    List<FuncViol> errors = new List<FuncViol>();

                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {
                                case "Test":
                                    if (reader.HasAttributes)
                                    {
                                        Test test = new Test();
                                        test.Assoc = new List<TestAssoc>();
                                        test.Id = reader.GetAttribute("id");
                                        if (reader.GetAttribute("pass") == "1")
                                        {
                                            test.Status = 0;
                                        }
                                        else if (reader.GetAttribute("fail") == "1")
                                        {
                                            test.Status = 1;
                                        }
                                        else
                                        {
                                            test.Status = 2;
                                        }
                                        test.Name = reader.GetAttribute("name");
                                        var ms = Int64.Parse(reader.GetAttribute("startTime"));
                                        test.StartTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).AddMilliseconds(ms);
                                        test.Time = TimeSpan.Parse(reader.GetAttribute("time"));
                                        if (reader.ReadToDescendant("assoc"))
                                        {
                                            do
                                            {
                                                TestAssoc assoc = new TestAssoc();
                                                assoc.Id = int.Parse(reader.GetAttribute("id"));
                                                assoc.Tag = reader.GetAttribute("tag");
                                                test.Assoc.Add(assoc);
                                            } while (reader.ReadToNextSibling("assoc"));
                                        }
                                        test.FuncViol = new List<FuncViol>();
                                        results.TestCases.Add(test.Id, test);
                                    }
                                    break;
                                case "FuncViol":
                                    if (reader.HasAttributes)
                                    {
                                        FuncViol viol = new FuncViol();
                                        viol.Msg = reader.GetAttribute("msg");
                                        viol.Cat = int.Parse(reader.GetAttribute("cat"));
                                        viol.TaskType = reader.GetAttribute("taskType");
                                        viol.TestCaseId = reader.GetAttribute("testCaseId");
                                        viol.Sev = int.Parse(reader.GetAttribute("sev"));
                                        errors.Add(viol);
                                    }
                                    break;
                                default:
                                    //do nothing
                                    break;
                            }
                        }
                    }
                    foreach (FuncViol error in errors)
                    {
                        Test test = null;
                        if (results.TestCases.TryGetValue(error.TestCaseId, out test))
                        {
                            test.FuncViol.Add(error);
                        }
                    }
                }


                return results;
            }
            else
            {
                throw new FileNotFoundException("File Not Found: " + filePath);
            }

        }
    }


}
