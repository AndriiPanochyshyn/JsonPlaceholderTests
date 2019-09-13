namespace Reporting.ExcelReport
{
    public class ExcelTestEntry
    {
        public string TestName { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }

        public ExcelTestEntry(LogEntry jsonLogEntry)
        {
            TestName = jsonLogEntry.TestName;
            Description = jsonLogEntry.Error;
            Result = jsonLogEntry.Result;
        }
    }
}
