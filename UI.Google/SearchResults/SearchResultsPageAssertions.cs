using NUnit.Framework;
using UI.Core;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.Google.SearchResults
{
    public class SearchResultsPageAssertions : PageAssertions<SearchResultsPageElements>
    {
        public SearchResultsPageAssertions(IPageInterface page) : base(page)
        {
        }

        public void DomainIsPresentOnPage(int pagesCount, string domain)
        {
            Page.WaitUntilVisible(Elements.SearchResults);
            Page.IsElementContainsText(Elements.SearchLinks, domain);

            for (int nextPageNumber = 2; nextPageNumber <= pagesCount; nextPageNumber++)
            {
                Page.ClickOn(Elements.Page(nextPageNumber));
                Page.WaitUntilVisible(Elements.SearchResults);

                if (Page.IsElementContainsText(Elements.SearchLinks, domain))
                   return;
            }

            Logger.Instance.TestFailed($"First {pagesCount} page don't contain domain {domain}");
            Assert.Fail();
        }
    }
}
