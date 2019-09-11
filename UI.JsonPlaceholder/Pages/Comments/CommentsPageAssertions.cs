using System.Collections.Generic;
using Models;
using Newtonsoft.Json;
using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.Comments
{
    public class CommentsPageAssertions : PageAssertions<CommentsPageElements>
    {
        public CommentsPageAssertions(IPageInterface page) : base(page)
        {
        }

        public void CheckEmailByBodyInnerText(string bodyInnerText, string expectedEmail)
        {
            Page.WaitUntilVisible(Elements.Content);

            var text = Page.GetText(Elements.Content);
            var comments = JsonConvert.DeserializeObject<List<Comment>>(text);

            foreach (var comment in comments)
            {
                if (comment.Body.Contains(bodyInnerText))
                {
                    Assert.That(comment.Email, Is.EqualTo(expectedEmail));
                    return;
                }
            }
            Assert.Fail($"Not a single comment contains text '{bodyInnerText}'");
        }
    }
}
