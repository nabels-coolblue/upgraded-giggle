using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpgradedGiggle.LogFileParsing.Data.LogLines
{
    public class NormalLine
    {
        public int Hour { get; set; }
        public string Nick { get; set; }
        public string Content { get; set; }
    }
}
