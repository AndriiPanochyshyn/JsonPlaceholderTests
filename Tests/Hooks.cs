using BoDi;
using TechTalk.SpecFlow;
using UI.Core;
using UI.Google;

namespace Tests
{
    [Binding]
    class Hooks
    {
        private static PageInterfaceProvider _pageInterfaceProvider;
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTests()
        {
            _pageInterfaceProvider = new PageInterfaceProvider();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _container.RegisterInstanceAs(_pageInterfaceProvider.PageInterface);
            _container.RegisterInstanceAs(_pageInterfaceProvider.Navigator);

            GoogleMainPageObject.Configure("https://www.google.com/");
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            _pageInterfaceProvider.Dispose();
        }
    }
}
