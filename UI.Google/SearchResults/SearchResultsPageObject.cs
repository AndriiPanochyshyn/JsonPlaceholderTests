using System;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.Google.SearchResults.WebSite;

namespace UI.Google.SearchResults
{
    public class SearchResultsPageObject : PageObject<SearchResultsPageAssertions, SearchResultsPageElements>
    {
        public RandomWebSitePageObject RandomWebSite { get; }

        public SearchResultsPageObject(IPageInterface page, SearchResultsPageAssertions pageAssertions, RandomWebSitePageObject randomWebSite) 
            : base(page, pageAssertions)
        {
            RandomWebSite = randomWebSite;
        }

        public void OpenFirstWebsite()
        {
            Page.WaitUntilVisible(Elements.SearchHeaders);
            Page.ClickOn(Elements.SearchHeaders);
            Page.WaitUntilNotVisible(Elements.SearchHeaders);
        }
    }
}
