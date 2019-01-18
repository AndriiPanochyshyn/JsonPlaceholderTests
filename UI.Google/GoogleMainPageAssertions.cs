using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.Google
{
    public class GoogleMainPageAssertions : PageAssertions<GoogleMainPageElements>
    {
        public GoogleMainPageAssertions(IPageInterface page) : base(page)
        {
        }
    }
}
