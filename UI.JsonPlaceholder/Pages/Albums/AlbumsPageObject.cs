using System.Linq;
using Models;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Albums
{
    public class AlbumsPageObject : PageObject<AlbumsPageAssertions, AlbumsPageElements>
    {
        private CommonPageObject _common{ get; }

        public AlbumsPageObject(IPageInterface page, AlbumsPageAssertions pageAssertions, CommonPageObject common) : base(page, pageAssertions)
        {
            _common = common;
        }

        public Album GetAlbumByAlbumId(int albumId)
        {
            return _common.GetContent<Album>().FirstOrDefault(album => album.Id == albumId);
        }
    }
}
