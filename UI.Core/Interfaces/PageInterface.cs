using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Core.Interfaces
{
    public class PageInterface : IPageInterface
    {
        private readonly IWebDriver _webDriver;

        public PageInterface(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement FindElement(string cssSelector)
        {
            return _webDriver.FindElement(By.CssSelector(cssSelector));
        }

        public void ClickOn(string cssSelector)
        {
            var element = FindElement(cssSelector);
            element.Click();
        }

        public string GetText(string cssSelector)
        {
            WaitUntilVisible(cssSelector);

            var element = FindElement(cssSelector);
            return element.Text;
        }

        public bool IsElementVisible(string cssSelector)
        {
            try
            {
                _webDriver.FindElement(By.CssSelector(cssSelector));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitUntilVisible(string cssSelector)
        {
            var wait = new WebDriverWait(_webDriver, PageInterfaceProvider.WaitUntilTimeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }
    }
}