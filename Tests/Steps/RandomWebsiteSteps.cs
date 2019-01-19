using TechTalk.SpecFlow;
using UI.Google;

namespace Tests.Steps
{
    [Binding]
    internal class RandomWebsiteSteps
    {
        private readonly GoogleMainPageObject _ui;

        public RandomWebsiteSteps(GoogleMainPageObject ui)
        {
            _ui = ui;
        }

        [Then(@"User expect website title contains '(.*)'")]
        public void ThenUserExpectWebsiteTitleContains(string text)
        {
            _ui.SearchResults.RandomWebSite.Assert.CheckTitle(text);
        }
    }
}
