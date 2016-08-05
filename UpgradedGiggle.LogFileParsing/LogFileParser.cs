using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpgradedGiggle.LogFileParsing.Data;
using UpgradedGiggle.LogFileParsing.Data.LogLines;
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
                {
                    var match = Regex.Match(logLine, REGEX_ACTIONLINE);

                    var actionLine = new ActionLine();
                    actionLine.Hour = int.Parse(match.Groups[1].Value);

                    result.ActionLines.Add(actionLine);
                }

                if (Regex.IsMatch(logLine, REGEX_THIRDLINE))
                    result.ThirdLines.Add(logLine);
            }

            result.Succeeded = true;
            return result;
        }
    }
}
