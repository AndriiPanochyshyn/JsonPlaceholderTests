using System.Linq;
using Models;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Photos
{
    public class PhotosPageObject : PageObject<PhotosPageAssertions, PhotosPageElements>
    {
        private CommonPageObject _common { get; }

        public PhotosPageObject(IPageInterface page, PhotosPageAssertions pageAssertions, CommonPageObject common) : base(page, pageAssertions)
        {
            _common = common;
        }

        public int GetAlbumIdByPhotoTitle(string photoTitle)
        {
            return (from photo in _common.GetContent<Photo>() where photo.Title == photoTitle select photo.AlbumId).FirstOrDefault();
        }
    }
}
