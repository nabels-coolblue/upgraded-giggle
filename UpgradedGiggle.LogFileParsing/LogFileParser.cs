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
                {
                    result.NormalLines.Add(ParseNormalLine(logLine));
                }
                if (Regex.IsMatch(logLine, REGEX_ACTIONLINE))
                {
                    result.ActionLines.Add(ParseActionLine(logLine));
                }
                if (Regex.IsMatch(logLine, REGEX_THIRDLINE))
                {
                    result.ThirdLines.Add(ParseThirdLine(logLine));
                }
            }

            result.Succeeded = true;
            return result;
        }

        public ActionLine ParseActionLine(string logLine)
        {
            var match = Regex.Match(logLine, REGEX_ACTIONLINE);

            var actionLine = new ActionLine();
            actionLine.Hour = int.Parse(match.Groups[1].Value);
            actionLine.Nick = match.Groups[2].Value;
            actionLine.Action = match.Groups[3].Value;

            return actionLine;
        }

        public NormalLine ParseNormalLine(string logLine)
        {
            var match = Regex.Match(logLine, REGEX_NORMALLINE);

            var normalLine = new NormalLine();
            normalLine.Hour = int.Parse(match.Groups[1].Value);
            normalLine.Nick = match.Groups[2].Value;
            normalLine.Content = match.Groups[3].Value;

            return normalLine;
        }

        public ThirdLine ParseThirdLine(string logLine)
        {
            var match = Regex.Match(logLine, REGEX_THIRDLINE);

            var thirdLine = new ThirdLine();
            thirdLine.Hour = int.Parse(match.Groups[1].Value);
            thirdLine.Nick = match.Groups[3].Value;

            return thirdLine;
        }
    }
}
