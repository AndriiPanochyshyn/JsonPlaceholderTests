using OpenQA.Selenium;
using System;

namespace UI.Core.Interfaces
{
    public class Navigator : INavigator
    {
        IWebDriver webDriver;

        public Navigator(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Open(Uri url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public string CurrentPath
        {
            get
            {
                return webDriver.Url;
            }
        }
    }
}
