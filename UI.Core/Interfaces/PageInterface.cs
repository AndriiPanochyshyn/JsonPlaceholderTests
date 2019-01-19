using System;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace UI.Core.Interfaces
{
    public class PageInterface : IPageInterface
    {
        private const string InputTagName = "input";
        private const string TextareaTagName = "textarea";
        private const string SelectTagName = "select";
        private readonly IWebDriver _webDriver;
        private static readonly List<string> InputElementTagNames = new List<string> { InputTagName, TextareaTagName };

        private Dictionary<string, string> keyboardKeys = new Dictionary<string, string>
        {
            { "Enter", Keys.Enter },
            { "f6", Keys.F6 }
        };

        public PageInterface(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string Title => _webDriver.Title;

        private IWebElement FindElement(string cssSelector)
        {
            return _webDriver.FindElement(By.CssSelector(cssSelector));
        }

        private IEnumerable<IWebElement> FindElements(string cssSelector)
        {
            return _webDriver.FindElements(By.CssSelector(cssSelector));
        }

        public void PressOnKeyboard(string cssSelector, string key)
        {
            IWebElement element = FindElement(cssSelector);
            element.SendKeys(keyboardKeys[key]);
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

        public void InputText(string cssSelector, string text)
        {
            IWebElement input = FindElement(cssSelector);
            Assert.That(InputElementTagNames.Contains(input.TagName), $"Cannot set value of [{input.TagName}] element.");

            input.Clear();
            input.SendKeys(text);
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

        public bool IsElementContainsText(string cssSelector, string record)
        {
            WaitUntilVisible(cssSelector);

            var elements = FindElements(cssSelector);
            try
            {
                foreach (var element in elements)
                {
                    if (element.Text.Contains(record))
                        return true;
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Wait(double seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        public void WaitUntilExists(string cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, PageInterfaceProvider.WaitUntilTimeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(cssSelector)));
        }

        public void WaitUntilVisible(string cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, PageInterfaceProvider.WaitUntilTimeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        public void WaitUntilNotVisible(string cssSelector)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_webDriver)
            {
                Timeout = PageInterfaceProvider.WaitUntilTimeout
            };

            wait.Until(x =>
            {
                try
                {
                    return !FindElement(cssSelector).Displayed;
                }
                catch (WebDriverException e) when (e is NoSuchElementException || e is StaleElementReferenceException)
                {
                    return true;
                }
            });
        }
    }
}