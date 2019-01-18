using UI.Core.Interfaces;

namespace UI.Core.Abstractions
{
    public abstract class PageAssertions<TElements>
        where TElements : PageElements, new()
    {
        protected TElements Elements;
        protected IPageInterface Page;

        protected PageAssertions(IPageInterface page)
        {
            Page = page;
            Elements = new TElements();
        }
    }
}
