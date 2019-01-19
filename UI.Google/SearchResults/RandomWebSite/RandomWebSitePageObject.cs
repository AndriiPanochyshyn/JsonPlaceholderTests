using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.Google.SearchResults.RandomWebSite;

namespace UI.Google.SearchResults.WebSite
{
    public class RandomWebSitePageObject : PageObject<RandomWebSitePageAssertions, RandomWebSitePageElements>
    {
        public RandomWebSitePageObject(IPageInterface page, RandomWebSitePageAssertions pageAssertions) : base(page, pageAssertions)
        {
        }
    }
}
