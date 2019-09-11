using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.Core.Interfaces
{
    public class PageInterface : IPageInterface
    {
        private const int ScrollYShift = 100;
        private const string InputTagName = "input";
        private const string TextareaTagName = "textarea";

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
            IWebElement element = FindElement(cssSelector);
            element.Click();
        }

        public string GetText(string cssSelector)
        {
            WaitUntilVisible(cssSelector);

            IWebElement element = FindElement(cssSelector);
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
            WebDriverWait wait = new WebDriverWait(_webDriver, PageInterfaceProvider.WaitUntilTimeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }
    }
}