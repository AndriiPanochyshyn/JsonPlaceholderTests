using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class CommentsSteps
    {
        private readonly JsonPlaceholderPageObject _ui;

        public CommentsSteps(JsonPlaceholderPageObject ui)
        {
            _ui = ui;
        }

        [When(@"User opens Comments page")]
        public void WhenUserOpensCommentsPage()
        {
            _ui.OpenComments();
        }

        [Then(@"User expects comment with text '(.*)' in body to have email '(.*)'")]
        public void ThenUserExpectsCommentWithTextInBodyToHaveEmail(string bodyInnerText, string email)
        {
            _ui.Pages.Comments.Assert.CheckEmailByBodyInnerText(bodyInnerText, email);
        }
    }
}
