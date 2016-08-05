using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UpgradedGiggle.LogFileParsing.Tests
{
    public class LogFileParserTests
    {
        private LogFile CreateSampleLogFile_WithHeaderActionsAndLogLines()
        {
            var sampleLogFileContents = System.IO.File.ReadAllLines("Samples/Sample_WithActionThirdAndNormalLines.txt");
            return new LogFile(sampleLogFileContents);
        }

        private LogFile CreateSampleLogFile_WithActionLine()
        {
            var sampleLogFileContents = System.IO.File.ReadAllLines("Samples/Sample_WithActionLine.txt");
            return new LogFile(sampleLogFileContents);
        }

        [Fact]
        public void LogFileParser_EnsureParsingSampleLogFile_WithActionThirdAndNormalLines_Works()
        {
            var logFile = CreateSampleLogFile_WithHeaderActionsAndLogLines();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void LogFileParser_EnsureParsingSampleLogFile_WithActionLine_Works()
        {
            var logFile = CreateSampleLogFile_WithActionLine();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void LogFileParser_EnsureParsingSampleLogFileReturns_ValidHighLevelTaxonomy()
        {
            var logFile = CreateSampleLogFile_WithHeaderActionsAndLogLines();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.NormalLines.Count > 1);
            Assert.True(result.ActionLines.Count == 1);
            Assert.True(result.ThirdLines.Count > 1);
        }


        [Fact]
        public void LogFileParser_WhenParsingActionLine_EnsureCorrectParsing()
        {
            var logFile = CreateSampleLogFile_WithActionLine();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.ActionLines.Count == 1);
        }
    }
}
