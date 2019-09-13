using System.Collections.Generic;

namespace Reporting.ExcelReport
{
    public static class ExcelFileReportGenerator
    {
        public static void CreateReport(List<LogEntry> logEntries)
        {
            ExcelFileLogWriter excelWriter = new ExcelFileLogWriter();

            excelWriter.AddTestsResults(logEntries);
            excelWriter.SaveFile();
        }
    }
}
