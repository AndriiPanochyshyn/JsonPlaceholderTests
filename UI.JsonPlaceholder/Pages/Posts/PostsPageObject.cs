using System.Linq;
using Models;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Posts
{
    public class PostsPageObject : PageObject<PostsPageAssertions, PostsPageElements>
    {
        private CommonPageObject _common { get; }

        public PostsPageObject(IPageInterface page, PostsPageAssertions pageAssertions, CommonPageObject common) : base(page, pageAssertions)
        {
            _common = common;
        }

        public int GetUserIdByTitle(string titleText)
        {
            return (from post in _common.GetContent<Post>() where post.Title == titleText select post.UserId).FirstOrDefault();
        }
    }
}
