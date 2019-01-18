using OpenQA.Selenium;

namespace UI.Core.Interfaces
{
    public class PageInterface : IPageInterface
    {
        private readonly IWebDriver _webDriver;

        public PageInterface(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}