using NUnit.Framework;
using Reporting;
using Reporting.ExcelReport;

namespace API.Tests
{
    [SetUpFixture]
    internal class Configuration
    {
        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            if (LogDataWriter.TestResults.Count > 0)
            {
                ExcelFileReportGenerator.CreateReport(LogDataWriter.TestResults);
            }
        }
    }
}
