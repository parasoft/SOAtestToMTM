using CommandLine;
using CommandLine.Text;

namespace SOAtestToMTM
{
    class Options
    {
        [Option("encrypt", HelpText = "Special command to generate a encrypted password")]
        public string Encrypt { get; set; }
        [Option("uri", Required = true, HelpText = "TFS Server URI, example: http://tfs.server.com:8080/tfs/DefaultCollection")]
        public string URI { get; set; }
        [Option("username", Required = true, HelpText = "TFS Username")]
        public string Username { get; set; }
        [Option("password", Required = true, HelpText = "Encrypted password, use MTMImporter.exe --encrypt 'password' command to generate")]
        public string Password { get; set; }
        [Option("domain", Required = true, HelpText = "User credential domain")]
        public string Domain { get; set; }
        [Option("project", Required = true, HelpText = "MTM project name")]
        public string Project { get; set; }
        [Option("report", Required = true, HelpText = "Path to SOAtest report.xml")]
        public string Report { get; set; }
        [HelpOption]
        public string GetUsage()
        {
            HelpText help = new HelpText();
            help.AddDashesToOption = true;
            help.AdditionalNewLineAfterOption = true;
            help.AddOptions(this);
            return help;
        }




    }
}
