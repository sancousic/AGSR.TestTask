using CommandLine;

namespace AGSR.DataTool
{
    internal sealed class Options
    {
        [Option('l', "locale",
            HelpText = "Localization of generated data. See https://github.com/bchavez/Bogus",
            Default = "en_US")]
        public string Locale { get; set; } = null!;

        [Option('u', "url", HelpText = "Base URL to AGSR.Patient API.",
            Default = "https://localhost:5001/")]
        public string BaseUrl { get; set; } = null!;

        [Option('c', "count", HelpText = "Number of entities created.",
            Default = 100)]
        public int Count { get; set; }
    }
}
