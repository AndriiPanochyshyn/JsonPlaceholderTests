using System;
using System.Configuration;
using System.IO;

namespace UI.Core
{
    public class Logger
    {
        private readonly string _logFilePath;
        private static readonly Lazy<Logger> LoggerLazy = new Lazy<Logger>(() => new Logger(), true);

        public static Logger Instance => LoggerLazy.Value;

        private Logger()
        {
            var logFileDirectory = ConfigurationManager.AppSettings["LogFilePath"];
            _logFilePath = CreateLogFile(logFileDirectory);
        }

        private static string CreateLogFile(string logFileDirectory)
        {
            var logFileName = $"{DateTime.Today:dd.MM.yyyy}.log";
            var logFilePath = Path.Combine(logFileDirectory, logFileName);
            var directoryInfo = new DirectoryInfo(logFileDirectory);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            return logFilePath;
        }

        private void Write(string logEntry) => File.AppendAllText(_logFilePath, string.Concat(logEntry, Environment.NewLine));
        public void TestPassed(string description) => Write($"Test passed: {description}");
        public void TestFailed(string error) => Write($"Test failed: {error}");
    }
}
