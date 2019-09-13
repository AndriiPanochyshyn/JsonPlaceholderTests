using NUnit.Framework.Internal;

namespace Reporting
{
    internal class LogEntryFactory
    {
        public static LogEntry CreateLogEntry(string testResult, string error = "")
        {
            var currentTest = TestExecutionContext.CurrentContext.CurrentTest;
            return new LogEntry
            {
                Result = testResult,
                TestName = $"{currentTest.ClassName}_{currentTest.MethodName}",
                Error = error
            };
        }
    }
}