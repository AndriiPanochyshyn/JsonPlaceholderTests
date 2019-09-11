using UI.JsonPlaceholder.Pages.Albums;
using UI.JsonPlaceholder.Pages.Comments;
using UI.JsonPlaceholder.Pages.Photos;
using UI.JsonPlaceholder.Pages.Posts;
using UI.JsonPlaceholder.Pages.Todos;
using UI.JsonPlaceholder.Pages.Users;

namespace UI.JsonPlaceholder.Pages
{
    public class Pages
    {
        public CommentsPageObject Comments { get; }
        public PostsPageObject Posts { get; }
        public UsersPageObject Users { get; }
        public PhotosPageObject Photos { get; }
        public AlbumsPageObject Albums { get; }
        public TodosPageObject Todos { get; }

        public Pages(CommentsPageObject comments, PostsPageObject posts, UsersPageObject users, PhotosPageObject photos, AlbumsPageObject albums, TodosPageObject todos)
        {
            Comments = comments;
            Posts = posts;
            Users = users;
            Photos = photos;
            Albums = albums;
            Todos = todos;
        }
    }
}
