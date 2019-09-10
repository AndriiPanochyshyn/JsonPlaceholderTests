using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder
{
    public class JsonPlaceholderPageAssertions : PageAssertions<JsonPlaceholderPageElements>
    {
        public JsonPlaceholderPageAssertions(IPageInterface page) : base(page)
        {
        }

        public void WaitMainPageOpening()
        {
            Page.WaitUntilVisible(Elements.Logo);

            Assert.That(Page.IsElementVisible(Elements.ResourcesPosts));
            Assert.That(Page.IsElementVisible(Elements.ResourcesComments));
            Assert.That(Page.IsElementVisible(Elements.ResourcesPhotos));
            Assert.That(Page.IsElementVisible(Elements.ResourcesTodos));
            Assert.That(Page.IsElementVisible(Elements.ResourcesUsers));
        }
    }
}
