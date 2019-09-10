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
            Page.WaitUntilVisible(Elements.Email(1));
            int blockIndex = 1; 

            while (Page.IsElementVisible(Elements.Body(blockIndex)))
            {
                if (Page.GetText(Elements.Body(blockIndex)).Contains(bodyInnerText))
                {
                    var actualEmail = Page.GetText(Elements.Email(blockIndex));
                    Assert.That(actualEmail, Is.EqualTo(expectedEmail));
                }
            }
        }
    }
}
