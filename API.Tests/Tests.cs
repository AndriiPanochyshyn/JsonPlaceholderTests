using System.Threading.Tasks;
using Models;
using NUnit.Framework;
using Api;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace API.Tests
{
    [TestFixture]
    internal class Tests
    {
        private JsonPlaceholderHttpClient _client;

        [SetUp]
        protected void SetUp()
        {
            _client = new JsonPlaceholderHttpClient();
        }

        [TestCase("Marcia@name.biz")]
        [TestCase("Jackeline@eva.tv")]
        public async Task ApiUserEmailChecking(string expectedEmail)
        {
            const string testBodyInnerText = "ipsum dolorem";

            var comments = await _client.GetAsync<List<Comment>>(Routes.Comments);

            foreach (var comment in comments)
            {
                if (comment.Body.Contains(testBodyInnerText))
                {
                    Assert.That(comment.Email, Is.EqualTo(expectedEmail));
                }
            }
        }

        [Test]
        public async Task ApiUserNameChecking()
        {
            const string postTitle = "eos dolorem iste accusantium est eaque quam";
            const string expectedUserName = "Patricia Lebsack";

            var posts = await _client.GetAsync<List<Post>>($"{Routes.Posts}?title={postTitle}");

            if (posts.Count == 0)
            {
                Assert.Fail($"Post with title '{postTitle}' not found");
            }

            var user = await _client.GetAsync<User>($"{Routes.Users}/{posts.FirstOrDefault().UserId}");

            Assert.That(user.Name, Is.EqualTo(expectedUserName));
        }

        [Test]
        public async Task ApiUserPhotoChecking()
        {
            const string photoTitle = "ad et natus qui";
            const string expectedEmail = "Sincere@april.biz";

            var photos = await _client.GetAsync<List<Photo>>($"{Routes.Photos}?title={photoTitle}");

            if (photos.Count == 0)
            {
                Assert.Fail($"Photo with title '{photoTitle}' not found");
            }

            var album = await _client.GetAsync<Album>($"{Routes.Albums}/{photos.FirstOrDefault().AlbumId}");
            var user = await _client.GetAsync<User>($"{Routes.Users}/{album.UserId}");

            Assert.That(user.Email, Is.EqualTo(expectedEmail));
        }

        #region ApiUserTodosChecking

        private int _firstUserId;
        private int _secondUserId;
        private List<Todo> _todos;

        [TestCase(3, "Leanne Graham", "Ervin Howell")]
        public async Task ApiUserTodosChecking(int difference, string firstUserName, string secondUserName)
        {
            Task[] tasks = new Task[]
            {
                SetUsers(firstUserName, secondUserName),
                SetTodos()
            };

            await Task.WhenAll(tasks);

            var firstUserCompletedTodos = _todos.Where(todo => todo.UserId == _firstUserId && todo.Completed);
            var secondUserCompletedTodos = _todos.Where(todo => todo.UserId == _secondUserId && todo.Completed);

            Assert.That(firstUserCompletedTodos.Count() >= secondUserCompletedTodos.Count() + difference, Is.True);
        }

        private async Task SetUsers(string firstUserName, string secondUserName)
        {
            var firstUser = await _client.GetAsync<List<User>>($"{Routes.Users}?name={firstUserName}");
            var secondUser = await _client.GetAsync<List<User>>($"{Routes.Users}?name={secondUserName}");

            _firstUserId = firstUser.FirstOrDefault().Id;
            _secondUserId = secondUser.FirstOrDefault().Id;

        }

        private async Task SetTodos()
        {
            _todos = await _client.GetAsync<List<Todo>>(Routes.Todos);
        }

        #endregion ApiUserTodosChecking

        [Test]
        public async Task ApiUserImageCorruptionChecking()
        {
            const int photoId = 4;
            Image testImage = Resources.TestImage;

            var expectedByteArray = GetBytesFromImage(testImage);
            var photo = await _client.GetAsync<Photo>($"{Routes.Photos}/{photoId}");
            var actualByteArray = await _client.GetByteAsync(photo.Url);

            Assert.That(actualByteArray.SequenceEqual(expectedByteArray));
        }

        public byte[] GetBytesFromImage(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
