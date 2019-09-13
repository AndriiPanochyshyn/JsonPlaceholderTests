using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    internal class ApiSteps
    {
        private readonly IRestApi _restClient;
        private HttpResponseMessage responseMessage;

        public ApiSteps(IRestApi restClient)
        {
            _restClient = restClient;
        }

        [Given(@"User adds new post to system through api request")]
        public async Task GivenUserAddsNewPostToSystemThroughApiRequest(PostDTO newPost)
        {
            responseMessage = await _restClient.PostAsync(Routes.Posts, newPost);
        }

        [Given(@"User put post in the system through api request")]
        public async Task GivenUserUpdatesPostInTheSystemThroughApiRequest(Post updatedPost)
        {
            responseMessage = await _restClient.PutAsync($"{Routes.Posts}/{updatedPost.Id}", updatedPost);
        }

        [Given(@"User patch post in the system through api request")]
        public async Task GivenUserPatchPostInTheSystemThroughApiRequest(Post updatedPost)
        {
            responseMessage = await _restClient.PatchAsync($"{Routes.Posts}/{updatedPost.Id}", updatedPost);
        }

        [Given(@"User deletes post with id '(.*)' from the system through api request")]
        public async Task GivenUserDeletesPostWithIdFromTheSystemThroughApiRequest(int postId)
        {
            responseMessage = await _restClient.DeleteAsync($"{Routes.Posts}/{postId}");
        }

        [Then(@"User expects reponse status to be '(.*)'")]
        public void ThenUserExpectsReponseStatusToBe(string expectedResponseStatus)
        {
            Assert.That(responseMessage.StatusCode.ToString(), Is.EqualTo(expectedResponseStatus));
        }
    }
}
