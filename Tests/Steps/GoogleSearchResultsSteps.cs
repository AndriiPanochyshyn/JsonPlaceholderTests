using TechTalk.SpecFlow;
using UI.Google;

namespace Tests.Steps
{
    [Binding]
    internal class GoogleSearchResultsSteps
    {
        private readonly GoogleMainPageObject _ui;

        public GoogleSearchResultsSteps(GoogleMainPageObject ui)
        {
            _ui = ui;
        }

        [When(@"User opens first link after search")]
        public void WhenUserOpensFirstLinkAfterSearch()
        {
            _ui.SearchResults.OpenFirstWebsite();
        }

        [Then(@"User check first '(.*)' pages for domain '(.*)' availability")]
        public void ThenICheckFirstPagesForDomainAvailability(int pagesCount, string domain)
        {
            _ui.SearchResults.Assert.DomainIsPresentOnPage(pagesCount, domain);
        }
    }
}
