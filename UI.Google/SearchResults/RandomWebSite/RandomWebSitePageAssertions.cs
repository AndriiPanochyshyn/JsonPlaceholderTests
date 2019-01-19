using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.Google.SearchResults.RandomWebSite
{
    public class RandomWebSitePageAssertions : PageAssertions<RandomWebSitePageElements>
    {
        public RandomWebSitePageAssertions(IPageInterface page) : base(page)
        {
        }

        public void CheckTitle(string text)
        {
            Page.WaitUntilExists(Elements.Title);
            Assert.That(Page.Title.ToLower().Contains(text));
        }
    }
}
