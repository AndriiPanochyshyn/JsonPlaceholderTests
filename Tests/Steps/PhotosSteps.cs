using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class PhotosSteps
    {
        private readonly JsonPlaceholderPageObject _ui;
        private readonly DataContainer _dataContainer;

        public PhotosSteps(JsonPlaceholderPageObject ui, DataContainer dataContainer)
        {
            _ui = ui;
            _dataContainer = dataContainer;
        }

        [When(@"User opens Photos page")]
        public void WhenUserOpensPhotosPage()
        {
            _ui.OpenPhotos();
        }

        [When(@"User gets album id where photo title is '(.*)'")]
        public void WhenUserGetAlbumIdWherePhotoTitleIs(string photoTitle)
        {
            var albumId = _ui.Pages.Photos.GetAlbumIdByPhotoTitle(photoTitle);
            _dataContainer.AddAlbumId(photoTitle, albumId);
        }
    }
}
