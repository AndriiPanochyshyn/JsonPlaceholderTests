using NUnit.Framework;
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

            for (int pageNumber = 2; pageNumber <= pagesCount; pageNumber++)
            {
                Page.ClickOn(Elements.Page(pageNumber));
                Page.WaitUntilVisible(Elements.SearchResults);

                if (Page.IsElementContainsText(Elements.SearchLinks, domain))
                   return;
            }

            Assert.Fail();
        }
    }
}
