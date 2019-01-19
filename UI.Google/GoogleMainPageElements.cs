using UI.Core.Abstractions;

namespace UI.Google
{
    public class GoogleMainPageElements : PageElements
    {
        public string GoogleSearchInput => "input[name='q']";
        public string GoogleLogo => "img[alt='Google']";

        public string DisplayKeyboard => "span.MiYK0e";
        public string VoiceSearch => "span.hb2Smf";

        public string SearchButton => "div.FPdoLc.VlcLAe input[name='btnK']";
        public string ImFeelingLuckyButton => "div.FPdoLc.VlcLAe input[name='btnI']";
    }
}
