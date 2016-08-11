using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UpgradedGiggle.LogFileParsing.Tests
{
    public class LogFileDiscovererTests
    {
        [Fact]
        public void LogFileDiscoverer_FindsCorrectNumberOfFiles()
        {
            var logFileParser = new LogFileDiscoverer("Samples", "*Sample*.txt");
            var logFiles = logFileParser.DiscoverLogFiles();

            Assert.True(logFiles.Count == 4);
        }
    }
}
