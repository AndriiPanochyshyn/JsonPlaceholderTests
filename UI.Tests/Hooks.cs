using Api;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Reporting;
using Reporting.ExcelReport;
using TechTalk.SpecFlow;
using UI.Core;
using UI.JsonPlaceholder;

namespace Tests
{
    [Binding]
    internal class Hooks
    {
        private readonly IObjectContainer _container;
        private static IRestApi _restClient;
        private static PageInterfaceProvider _pageInterfaceProvider;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTests()
        {
            _pageInterfaceProvider = new PageInterfaceProvider();
            _restClient = new JsonPlaceholderHttpClient();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _container.RegisterInstanceAs(_pageInterfaceProvider.PageInterface);
            _container.RegisterInstanceAs(_pageInterfaceProvider.Navigator);
            _container.RegisterInstanceAs(_restClient);

            JsonPlaceholderPageObject.Configure(Routes.Url);
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            var testResult = TestContext.CurrentContext.Result;
            if (testResult.Outcome.Status == TestStatus.Failed)
                Logger.Instance.TestFailed(testResult.Message);
            else
                Logger.Instance.TestPassed();
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            if (LogDataWriter.TestResults.Count > 0)
            {
                ExcelFileReportGenerator.CreateReport(LogDataWriter.TestResults);
            }
            _pageInterfaceProvider.Dispose();
        }
    }
}
