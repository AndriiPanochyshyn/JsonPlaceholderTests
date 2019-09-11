using NUnit.Framework;
using TechTalk.SpecFlow;
using UI.JsonPlaceholder;

namespace Tests.Steps
{
    [Binding]
    internal class TodosSteps
    {
        private readonly JsonPlaceholderPageObject _ui;
        private readonly DataContainer _dataContainer;

        public TodosSteps(JsonPlaceholderPageObject ui, DataContainer dataContainer)
        {
            _ui = ui;
            _dataContainer = dataContainer;
        }

        [When(@"User opens Todos page")]
        public void WhenUserOpensTodosPage()
        {
            _ui.OpenTodos();
        }

        [Then(@"User expects user with name '(.*)' has more than '(.*)' completed TODOs than user with name '(.*)'")]
        public void ThenUserExpectsUserWithNameHasMoreThanCompletedTODOsThanUserWithName(string firstUser, int todosCount, string secondUser)
        {
            var firstUserCompletedTodos = _ui.Pages.Todos.GetCompletedTodos(todo => todo.UserId == _dataContainer.GetUserId(firstUser) && todo.Completed);
            var secondUserCompletedTodos = _ui.Pages.Todos.GetCompletedTodos(todo => todo.UserId == _dataContainer.GetUserId(secondUser) && todo.Completed);

            Assert.That(firstUserCompletedTodos.Count >= secondUserCompletedTodos.Count + todosCount, Is.True);
        }
    }
}
