using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.CommonPagesLogic
{
    public class CommonPageAssertions : PageAssertions<CommonPageElements>
    {
        public CommonPageAssertions(IPageInterface page) : base(page)
        {
        }
    }
}
