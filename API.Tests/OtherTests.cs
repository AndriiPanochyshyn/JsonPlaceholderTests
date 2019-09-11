using System.Net;
using System.Threading.Tasks;
using Models;
using NUnit.Framework;
using Api;
using System.Net.Http;

namespace API.Tests
{
    [TestFixture]
    internal class OtherTests
    {
        private IRestApi _restClient;

        [SetUp]
        protected void SetUp()
        {
            _restClient = new JsonPlaceholderHttpClient();
        }

        // Important: the resource will not be really created on the server but it will be faked as if.
        // In other words, if you try to access a post using 101 as an id, you'll get a 404 error
        [TestCase(1, "Test title", "Test body")]
        public async Task ApiCheckNewPostCanBeAddedIntoTheSystem(int userId, string title, string body)
        {
            const int newPostId = 101;
            var testPost = new PostDTO()
            {
                UserId = userId,
                Title = title,
                Body = body
            };

            var createdResponseMessage = await _restClient.PostAsync(Routes.Posts, testPost);
            var notFoundResponseMessage = await _restClient.GetResponseAsync($"{Routes.Posts}/{newPostId}");

            Assert.That(createdResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(notFoundResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        // Important: the resource will not be really updated on the server but it will be faked as if.
        [TestCase(UpdateMethod.Put , 1, 1, "Updated test title", "Updated test body")]
        [TestCase(UpdateMethod.Patch, 1, 1, "Updated test title", "Updated test body")]
        public async Task ApiCheckPostCanBeUpdatedIntoTheSystem(UpdateMethod updateMethod, int userId, int id, string title, string body)
        {
            var testUpdateData = new Post()
            {
                UserId = userId,
                Id = id,
                Title = title,
                Body = body
            };

            var updateResponseMessade = new HttpResponseMessage();
            if (updateMethod == UpdateMethod.Put)
                updateResponseMessade = await _restClient.PutAsync($"{Routes.Posts}/{id}", testUpdateData);
            else if (updateMethod == UpdateMethod.Patch)
                updateResponseMessade = await _restClient.PatchAsync($"{Routes.Posts}/{id}", testUpdateData);

            Assert.That(updateResponseMessade.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        //Important: the resource will not be really deleted on the server but it will be faked as if.
        [Test]
        public async Task ApiCheckPostCanBeDeletedFromTheSystem()
        {
            const int id = 1;
            var deletedResponseMessage = await _restClient.DeleteAsync($"{Routes.Posts}/{id}");

            Assert.That(deletedResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
