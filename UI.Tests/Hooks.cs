using Api;
using BoDi;
using TechTalk.SpecFlow;
using UI.Core;
using UI.JsonPlaceholder;

namespace Tests
{
    [Binding]
    internal class Hooks
    {
        private readonly IObjectContainer _container;
        private static PageInterfaceProvider _pageInterfaceProvider;

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

            JsonPlaceholderPageObject.Configure(Routes.Url);
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
