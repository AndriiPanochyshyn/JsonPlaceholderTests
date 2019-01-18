using TechTalk.SpecFlow;
using UI.Google;

namespace Tests.Steps
{
    [Binding]
    internal class GoogleMainPageSteps
    {
        private readonly GoogleMainPageObject _ui;

        public GoogleMainPageSteps(GoogleMainPageObject ui)
        {
            _ui = ui;
        }

        [Given(@"User opens Google main page")]
        public void GivenUserOpenGoogleMainPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"User input '(.*)' to google entry field")]
        public void GivenUserInputToGoogleEntryField(string p0)
        {
        }

        [Then(@"User press '(.*)' on keyboard")]
        public void ThenUserPressOnKeyboard(string p0)
        {
        }
    }
}
