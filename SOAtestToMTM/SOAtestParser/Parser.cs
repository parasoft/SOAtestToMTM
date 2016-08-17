using System.Xml.Serialization;
using System.IO;

public class Parser
{
    public ResultsSession parse(string pathToXmlFile)
    {
        var serializer = new XmlSerializer(typeof(ResultsSession));
        var reader = new StreamReader(pathToXmlFile);
        ResultsSession results = (ResultsSession)serializer.Deserialize(reader);
        return results;

    }
}
