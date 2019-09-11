using System.Threading.Tasks;
using Models;
using NUnit.Framework;
using Api;
using System.Collections.Generic;

namespace API.Tests
{
    [TestFixture]
    internal class Tests
    {
        [TestCase("Marcia@name.biz")]
        [TestCase("Jackeline@eva.tv")]
        public async Task ApiUserEmailChecking(string expectedEmail)
        {
            const string testBodyInnerText = "ipsum dolorem";

            var comments = await JsonPlaceholderHttpClient.GetAsync<List<Comment>>(Routes.Comments);

            foreach (var comment in comments)
                if (comment.Body.Contains(testBodyInnerText))
                    Assert.That(comment.Email, Is.EqualTo(expectedEmail));
        }

        [Test]
        public async Task ApiUserNameChecking()
        {
            string actualUserName = null;
            const string postTitle = "eos dolorem iste accusantium est eaque quam";
            const string expectedUserName = "Patricia Lebsack";

            var posts = await JsonPlaceholderHttpClient.GetAsync<List<Post>>($"{Routes.Posts}?title={postTitle}");

            foreach (var post in posts)
            {
                if (post.Title == postTitle)
                {
                    var user = await JsonPlaceholderHttpClient.GetAsync<User>($"{Routes.Users}/{post.UserId}");
                    actualUserName = user.Name;
                    break;
                }
            }

            Assert.That(actualUserName, Is.EqualTo(expectedUserName));
        }

        [Test]
        public async Task ApiUserPhotoChecking()
        {
            const string photoTitle = "ad et natus qui";
            const string expectedEmail = "Sincere@april.biz";
        }
    }
}
