using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.Posts
{
    public class PostsPageAssertions : PageAssertions<PostsPageElements>
    {
        public PostsPageAssertions(IPageInterface page) : base(page)
        {
        }
    }
}
