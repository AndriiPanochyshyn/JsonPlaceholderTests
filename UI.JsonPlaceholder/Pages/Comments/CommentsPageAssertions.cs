using Models;
using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Comments
{
    public class CommentsPageAssertions : PageAssertions<CommentsPageElements>
    {
        private CommonPageObject _common { get; }

        public CommentsPageAssertions(IPageInterface page, CommonPageObject common) : base(page)
        {
            _common = common;
        }

        public void CheckEmailByBodyInnerText(string bodyInnerText, string expectedEmail)
        {
            foreach (var comment in _common.GetContent<Comment>())
            {
                if (!comment.Body.Contains(bodyInnerText)) continue;
                Assert.That(comment.Email, Is.EqualTo(expectedEmail));
                return;
            }
            Assert.Fail($"Not a single comment contains body with text '{bodyInnerText}'");
        }
    }
}
