using UI.Core.Interfaces;

namespace UI.Core.Abstractions
{
    public abstract class PageObject<TAssertions, TElements>
        where TAssertions : PageAssertions<TElements>
        where TElements : PageElements, new()
    {
        protected TElements Elements;
        protected IPageInterface Page;

        protected PageObject(IPageInterface page, TAssertions pageAssertions)
        {
            Assert = pageAssertions;
            Page = page;
            Elements = new TElements();
        }

        public TAssertions Assert { get; }
    }
}
