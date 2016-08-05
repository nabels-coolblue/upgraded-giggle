using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpgradedGiggle.LogFileParsing.Data;
using System.Text.RegularExpressions;

namespace UpgradedGiggle.LogFileParsing
{
    public class IrssiLogFileParser
    {
        private const string REGEX_NORMALLINE = @"^(\d+):\d+[^<*^!]+<[@%+~& ]?([^>]+)> (.*)";
        private const string REGEX_ACTIONLINE = @"^(\d+):\d+[^ ]+ +\* (\S+) (.*)";
        private const string REGEX_THIRDLINE = @"^(\d+):(\d+)[^-]+-\!- (\S+) (\S+) (\S+) (\S+) (\S+)(.*)";
        
        public LogFileParseResult Parse(LogFile logFile)
        {
            var result = new LogFileParseResult();

            foreach (var logLine in logFile.RawContent)
            {
                if (Regex.IsMatch(logLine, REGEX_NORMALLINE))
                    result.NormalLines.Add(logLine);
                if (Regex.IsMatch(logLine, REGEX_ACTIONLINE))
                    result.ActionLines.Add(logLine);
                if (Regex.IsMatch(logLine, REGEX_THIRDLINE))
                    result.ThirdLines.Add(logLine);
            }

            result.Succeeded = true;
            return result;
        }
    }
}
