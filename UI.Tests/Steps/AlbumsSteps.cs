using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class AlbumsSteps
    {
        private readonly JsonPlaceholderPageObject _ui;
        private readonly DataContainer _dataContainer;

        public AlbumsSteps(JsonPlaceholderPageObject ui, DataContainer dataContainer)
        {
            _ui = ui;
            _dataContainer = dataContainer;
        }

        [When(@"User opens Albums page")]
        public void WhenUserOpensAlbumsPage()
        {
            _ui.OpenAlbums();
        }

        [When(@"User gets user id where album has photo with title '(.*)'")]
        public void WhenUserGetUserIdWhereAlbumHasPhotoWithTitle(string photoTitle)
        {
            var albumId = _dataContainer.GetAlbumId(photoTitle);
            var album = _ui.Pages.Albums.GetAlbumByAlbumId(albumId);

            _dataContainer.AddUserId(photoTitle, album.UserId);
        }
    }
}
