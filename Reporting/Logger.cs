using System;

namespace Reporting
{
    public class Logger
    {
        private readonly LogDataWriter _logDataWriter;
        private static readonly Lazy<Logger> LoggerLazy = new Lazy<Logger>(() => new Logger(), true);
        public static Logger Instance => LoggerLazy.Value;

        private Logger()
        {
            _logDataWriter = new LogDataWriter();
        }

        public void TestPassed()
        {
            var logEntry = LogEntryFactory.CreateLogEntry(TestState.Pass);
            _logDataWriter.Write(logEntry);
        } 

        public void TestFailed(string error)
        {
            var logEntry = LogEntryFactory.CreateLogEntry(TestState.Fail, error);
            _logDataWriter.Write(logEntry);
        }
    }
}