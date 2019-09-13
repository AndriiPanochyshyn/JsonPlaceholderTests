using System.Collections.Generic;

namespace Reporting
{
    public class LogDataWriter
    {
        public static List<LogEntry> TestResults;

        public LogDataWriter()
        {
            TestResults = new List<LogEntry>();
        }

        public void Write(LogEntry logEntry)
        {
            TestResults.Add(logEntry);
        }
    }
}