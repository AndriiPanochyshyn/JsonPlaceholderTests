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
            _ui.Open();
            _ui.Assert.WaitMainPageOpening();
        }

        [Given(@"User input '(.*)' to google entry field")]
        public void GivenUserInputToGoogleEntryField(string searchText)
        {
            _ui.SetSearch(searchText);
        }

        [Given(@"User press '(.*)' on keyboard after input text to google")]
        [Then(@"User press '(.*)' on keyboard after input text to google")]
        public void ThenUserPressOnKeyboard(string button)
        {
            _ui.PressOnKeyboard(button);
        }
    }
}
