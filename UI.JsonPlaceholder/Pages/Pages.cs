using UI.JsonPlaceholder.Pages.Comments;

namespace UI.JsonPlaceholder.Pages
{
    public class Pages
    {
        public CommentsPageObject Comments { get; }

        public Pages(CommentsPageObject comments)
        {
            Comments = comments;
        }
    }
}
