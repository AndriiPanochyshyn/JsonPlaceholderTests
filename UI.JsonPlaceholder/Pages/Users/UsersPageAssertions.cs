using Models;
using NUnit.Framework;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.Users
{
    public class UsersPageAssertions : PageAssertions<UsersPageElements>
    {
        public UsersPageAssertions(IPageInterface page) : base(page)
        {
        }

        public void CheckUserName(User user, string expecterUserName)
        {
            Assert.That(user.Name, Is.EqualTo(expecterUserName));
        }

        public void CheckUserEmail(User user, string expectedUserEmail)
        {
            Assert.That(user.Email, Is.EqualTo(expectedUserEmail));
        }
    }
}
