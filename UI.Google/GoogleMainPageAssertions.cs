using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.Google
{
    public class GoogleMainPageAssertions : PageAssertions<GoogleMainPageElements>
    {
        public GoogleMainPageAssertions(IPageInterface page) : base(page)
        {
        }

        public void WaitMainPageOpening()
        {
            Page.WaitUntilVisible(Elements.GoogleSearchInput);

            Assert.That(Page.IsElementVisible(Elements.GoogleLogo));
            Assert.That(Page.IsElementVisible(Elements.DisplayKeyboard));
            Assert.That(Page.IsElementVisible(Elements.VoiceSearch));
            Assert.That(Page.IsElementVisible(Elements.SearchButton));
            Assert.That(Page.IsElementVisible(Elements.ImFeelingLuckyButton));
        }
    }
}
