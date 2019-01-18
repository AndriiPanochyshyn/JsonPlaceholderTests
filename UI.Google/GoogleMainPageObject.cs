using System;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.Google
{
    public class GoogleMainPageObject : PageObject<GoogleMainPageAssertions, GoogleMainPageElements>
    {
        private readonly INavigator _navigator;
        private static Uri _baseUrl;

        public string CurrentUrl => _navigator.CurrentPath;

        public GoogleMainPageObject(IPageInterface page, GoogleMainPageAssertions pageAssertions, INavigator navigator) 
            : base(page, pageAssertions)
        {
            _navigator = navigator;
        }

        public static void Configure(string baseUrl)
        {
            _baseUrl = new Uri(baseUrl);
        }

        public void Open(string relativePath = null)
        {
            Uri relativeUrl = null;
            if (relativePath != null)
                relativeUrl = new Uri(relativePath, UriKind.Relative);
            var destination = relativeUrl == null ? _baseUrl : new Uri(_baseUrl, relativeUrl);
            _navigator.Open(destination);
        }
    }
}
