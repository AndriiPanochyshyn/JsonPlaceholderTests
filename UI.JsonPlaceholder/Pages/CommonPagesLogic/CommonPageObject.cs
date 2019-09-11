using System.Collections.Generic;
using Newtonsoft.Json;
using UI.Core.Abstractions;
using UI.Core.Interfaces;

namespace UI.JsonPlaceholder.Pages.CommonPagesLogic
{
    public class CommonPageObject : PageObject<CommonPageAssertions, CommonPageElements>
    {
        public CommonPageObject(IPageInterface page, CommonPageAssertions pageAssertions) : base(page, pageAssertions)
        {
        }

        public List<TJsonObject> GetContent<TJsonObject>()
        {
            Page.WaitUntilVisible(Elements.Content);
            return JsonConvert.DeserializeObject<List<TJsonObject>>(Page.GetText(Elements.Content));
        }
    }
}
