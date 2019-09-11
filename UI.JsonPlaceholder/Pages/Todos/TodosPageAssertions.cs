using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.Todos
{
    public class TodosPageAssertions : PageAssertions<TodosPageElements>
    {
        public TodosPageAssertions(IPageInterface page) : base(page)
        {
        }
    }
}
