using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class UsersSteps
    {
        private readonly JsonPlaceholderPageObject _ui;
        private readonly DataContainer _dataContainer;

        public UsersSteps(JsonPlaceholderPageObject ui, DataContainer dataContainer)
        {
            _ui = ui;
            _dataContainer = dataContainer;
        }

        [When(@"User opens Users page")]
        public void WhenUserOpenUsersPage()
        {
            _ui.OpenUsers();
        }

        [When(@"User get user ids with names:")]
        public void WhenUserGetUserIdsWithNames(Table table)
        {
            var names = table.ToList();

            foreach (var name in names)
            {
                var user = _ui.Pages.Users.GetUser(x => x.Name == name);
                _dataContainer.AddUserId(name, user.Id);
            }
        }

        [Then(@"User expects user name who has a post with title '(.*)' to be '(.*)'")]
        public void ThenUserExpectsUserNameWhoHasAPostWithTitleToBe(string text, string expectedUserName)
        {
            var userId = _dataContainer.GetUserId(text);
            var user = _ui.Pages.Users.GetUser(x => x.Id == userId);

            _ui.Pages.Users.Assert.CheckUserName(user, expectedUserName);
        }

        [Then(@"User expects user email who has an photo with title '(.*)' to be '(.*)'")]
        public void ThenUserExpectsUserEmailWhoHasAnPhotoWithTitleToBe(string photoTitle, string expectedUserEmail)
        {
            var userId = _dataContainer.GetUserId(photoTitle);
            var user = _ui.Pages.Users.GetUser(x => x.Id == userId);

            _ui.Pages.Users.Assert.CheckUserEmail(user, expectedUserEmail);
        }
    }
}
