using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpgradedGiggle.LogFileParsing.Data.LogLines;

namespace UpgradedGiggle.LogFileParsing.Data
{
    public class LogFileParseResult
    {
        public bool Succeeded { get; set; }

        public List<string> NormalLines { get; set; }

        public List<ActionLine> ActionLines { get; set; }

        public List<string> ThirdLines { get; set; }

        public LogFileParseResult()
        {
            NormalLines = new List<string>();
            ActionLines = new List<ActionLine>();
            ThirdLines = new List<string>();
        }
    }
}
