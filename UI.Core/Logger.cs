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
            string logFileDirectory = ConfigurationManager.AppSettings["LogFilePath"];
            _logFilePath = CreateLogFile(logFileDirectory);
        }

        private string CreateLogFile(string logFileDirectory)
        {
            string logFileName = $"{DateTime.Today:dd.MM.yyyy}.log";
            string logFilePath = Path.Combine(logFileDirectory, logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFileDirectory);
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
