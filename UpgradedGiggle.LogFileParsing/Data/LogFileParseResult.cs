using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpgradedGiggle.LogFileParsing.Data
{
    public class LogFileParseResult
    {
        public bool Succeeded { get; set; }

        public List<string> NormalLines { get; set; }

        public List<string> ActionLines { get; set; }

        public List<string> ThirdLines { get; set; }

        public LogFileParseResult()
        {
            NormalLines = new List<string>();
            ActionLines = new List<string>();
            ThirdLines = new List<string>();
        }
    }
}
