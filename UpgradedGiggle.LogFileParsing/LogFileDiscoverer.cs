using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace UpgradedGiggle.LogFileParsing
{
    public class LogFileDiscoverer
    {
        private string _path;
        private readonly string _logFileFilter;

        public LogFileDiscoverer(string path, string logFileFilter)
        {
            _path = path;
            _logFileFilter = logFileFilter;
        }

        public List<LogFile> DiscoverLogFiles()
        {
            var logFiles = new List<LogFile>();

            var foundFiles = Directory.EnumerateFiles(_path, _logFileFilter, SearchOption.AllDirectories).ToList();
            foundFiles.Sort();
            
            foreach (string file in foundFiles)
            {
                var logFileContents = File.ReadAllLines(file);
                var logFile = new LogFile(logFileContents);
                logFiles.Add(logFile);
            }

            return logFiles;
        }
    }
}
