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

        private LogFile CreateSampleLogFile_WithNormalLine()
        {
            var sampleLogFileContents = System.IO.File.ReadAllLines("Samples/Sample_WithNormalLine.txt");
            return new LogFile(sampleLogFileContents);
        }

        private LogFile CreateSampleLogFile_WithThirdLines()
        {
            var sampleLogFileContents = System.IO.File.ReadAllLines("Samples/Sample_WithThirdLines.txt");
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
        public void LogFileParser_EnsureParsingSampleLogFile_WithNormalLine_Works()
        {
            var logFile = CreateSampleLogFile_WithNormalLine();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void LogFileParser_EnsureParsingSampleLogFile_WithThirdLines_Works()
        {
            var logFile = CreateSampleLogFile_WithThirdLines();
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
            Assert.True(result.ActionLines.First().Hour == 16);
            Assert.True(result.ActionLines.First().Nick == "azimuth");
            Assert.True(result.ActionLines.First().Action == "does something to roger");
        }
        
        [Fact]
        public void LogFileParser_WhenParsingNormalLine_EnsureCorrectParsing()
        {
            var logFile = CreateSampleLogFile_WithNormalLine();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);

            Assert.True(result.NormalLines.Count == 1);
            Assert.True(result.NormalLines.First().Hour == 09);
            Assert.True(result.NormalLines.First().Nick == "belanda");
            Assert.True(result.NormalLines.First().Content == "good news everyone!");
        }

        [Fact]
        public void LogFileParser_WhenParsingThirdLines_EnsureCorrectParsing()
        {
            var logFile = CreateSampleLogFile_WithThirdLines();
            var logFileParser = new IrssiLogFileParser();
            var result = logFileParser.Parse(logFile);
            Assert.True(result.ThirdLines.Count == 9);
        }
    }
}
