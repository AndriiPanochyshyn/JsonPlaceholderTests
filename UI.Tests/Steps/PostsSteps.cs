using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class PostsSteps
    {
        private readonly JsonPlaceholderPageObject _ui;
        private readonly DataContainer _dataContainer;

        public PostsSteps(JsonPlaceholderPageObject ui, DataContainer dataContainer)
        {
            _ui = ui;
            _dataContainer = dataContainer;
        }

        [When(@"User opens Posts page")]
        public void WhenUserOpensPostsPage()
        {
            _ui.OpenPosts();
        }

        [When(@"User get user id who has a post with title '(.*)'")]
        public void WhenUserGetUserIdWhoHasAPostWithTitle(string title)
        {
            var userId = _ui.Pages.Posts.GetUserIdByTitle(title);
            _dataContainer.AddUserId(title, userId);
        }
    }
}
