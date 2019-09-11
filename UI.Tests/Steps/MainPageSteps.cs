using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class MainPageSteps
    {
        private readonly JsonPlaceholderPageObject _ui;

        public MainPageSteps(JsonPlaceholderPageObject ui)
        {
            _ui = ui;
        }

        [Given(@"User opens JsonPlaceholder main page")]
        [When(@"User opens JsonPlaceholder main page")]
        public void GivenUserOpensJsonPlaceholderMainPage()
        {
            _ui.Open();
            _ui.Assert.WaitMainPageOpening();
        }
    }
}
