using Models;
using NUnit.Framework;
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

        [Then(@"User expects post to be exist")]
        public void ThenUserExpectsPostToBeExist(Post expectedPost)
        {
            var actualPosts = _ui.Pages.Posts.GetAll();

            foreach (var actualPost in actualPosts)
            {
                if (actualPost.Equals(expectedPost))
                {
                    return;
                }
            }

            Assert.Fail($"Posts list doesn't contail post: {expectedPost}");
        }

        [Then(@"User expects post doesn't exist")]
        public void ThenUserExpectsPostDoesnTExist(Post expectedPost)
        {
            var actualPosts = _ui.Pages.Posts.GetAll();

            foreach (var actualPost in actualPosts)
            {
                Assert.That(actualPost.Equals(expectedPost), Is.False);
            }
        }
    }
}
