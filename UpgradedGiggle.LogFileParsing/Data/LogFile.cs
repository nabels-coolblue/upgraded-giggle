using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpgradedGiggle.LogFileParsing
{
    public class LogFile
    {
        public LogFile() { }
        public LogFile(string[] rawContent) { RawContent = rawContent; }

        public string[] RawContent { get; }
    }
}
