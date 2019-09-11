using System;
using System.Linq;
using Models;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Users
{
    public class UsersPageObject : PageObject<UsersPageAssertions, UsersPageElements>
    {
        private CommonPageObject _common { get; }

        public UsersPageObject(IPageInterface page, UsersPageAssertions pageAssertions, CommonPageObject common) : base(page, pageAssertions)
        {
            _common = common;
        }

        public User GetUser(Func<User, bool> predicate)
        {
            return _common.GetContent<User>().FirstOrDefault(predicate);
        }
    }
}
