using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.Comments
{
    public class CommentsPageObject : PageObject<CommentsPageAssertions, CommentsPageElements>
    {
        public CommentsPageObject(IPageInterface page, CommentsPageAssertions pageAssertions) : base(page, pageAssertions)
        {
        }
    }
}
