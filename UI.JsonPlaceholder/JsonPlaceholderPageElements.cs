using UI.Core.Abstractions;

namespace UI.JsonPlaceholder
{
    public class JsonPlaceholderPageElements : PageElements
    {
        public string Logo => "div.container h1";

        #region Resources

        private static string ResourceLink(string name) => $"table.resources a[href='/{name}']";

        public string ResourcesPosts => $"{ResourceLink("posts")}";
        public string ResourcesComments => $"{ResourceLink("comments")}";
        public string ResourcesPhotos => $"{ResourceLink("photos")}";
        public string ResourcesAlbums => $"{ResourceLink("albums")}";
        public string ResourcesTodos => $"{ResourceLink("todos")}";
        public string ResourcesUsers => $"{ResourceLink("users")}";

        #endregion Resources
    }
}
