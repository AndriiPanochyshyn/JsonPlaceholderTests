using System;
using System.Collections.Generic;
using Models;
using UI.Core.Abstractions;
using UI.Core.Interfaces;
using System.Linq;
using UI.JsonPlaceholder.Pages.CommonPagesLogic;

namespace UI.JsonPlaceholder.Pages.Todos
{
    public class TodosPageObject : PageObject<TodosPageAssertions, TodosPageElements>
    {
        private CommonPageObject _common { get; }

        public TodosPageObject(IPageInterface page, TodosPageAssertions pageAssertions, CommonPageObject common) : base(page, pageAssertions)
        {
            _common = common;
        }

        public List<Todo> GetCompletedTodos(Func<Todo, bool> predicate)
        {
            return _common.GetContent<Todo>().Where(predicate).ToList();
        }
    }
}
