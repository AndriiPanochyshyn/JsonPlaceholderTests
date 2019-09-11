using System;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder
{
    public class JsonPlaceholderPageObject : PageObject<JsonPlaceholderPageAssertions, JsonPlaceholderPageElements>
    {
        private readonly INavigator _navigator;
        private static Uri _baseUrl;

        public Pages.Pages Pages { get; }

        public JsonPlaceholderPageObject(IPageInterface page, JsonPlaceholderPageAssertions pageAssertions, INavigator navigator, Pages.Pages pages) 
            : base(page, pageAssertions)
        {
            _navigator = navigator;
            Pages = pages;
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

        public void OpenComments()
        {
            Page.WaitUntilVisible(Elements.ResourcesComments);
            Page.ClickOn(Elements.ResourcesComments);
        }

        public void OpenPosts()
        {
            Page.WaitUntilVisible(Elements.ResourcesPosts);
            Page.ClickOn(Elements.ResourcesPosts);
        }

        public void OpenUsers()
        {
            Page.WaitUntilVisible(Elements.ResourcesUsers);
            Page.ClickOn(Elements.ResourcesUsers);
        }

        public void OpenPhotos()
        {
            Page.WaitUntilVisible(Elements.ResourcesPhotos);
            Page.ClickOn(Elements.ResourcesPhotos);
        }

        public void OpenAlbums()
        {
            Page.WaitUntilVisible(Elements.ResourcesAlbums);
            Page.ClickOn(Elements.ResourcesAlbums);
        }

        public void OpenTodos()
        {
            Page.WaitUntilVisible(Elements.ResourcesTodos);
            Page.ClickOn(Elements.ResourcesTodos);
        }
    }
}
