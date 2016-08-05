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

        public List<NormalLine> NormalLines { get; set; }

        public List<ActionLine> ActionLines { get; set; }

        public List<ThirdLine> ThirdLines { get; set; }

        public LogFileParseResult()
        {
            NormalLines = new List<NormalLine>();
            ActionLines = new List<ActionLine>();
            ThirdLines = new List<ThirdLine>();
        }
    }
}
