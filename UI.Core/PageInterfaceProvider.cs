using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using UI.Core.Interfaces;

namespace UI.Core
{
    public class PageInterfaceProvider : IDisposable
    {
        readonly IWebDriver webDriver;

        public IPageInterface PageInterface { get; }
        public INavigator Navigator { get; }

        public static TimeSpan WaitUntilTimeout => TimeSpan.FromSeconds(60);
        public static TimeSpan WaitForNotExpectableTimeout => TimeSpan.FromSeconds(2);

        public PageInterfaceProvider()
        {
            webDriver = StartUpWebDriver();
            PageInterface = new PageInterface(webDriver);
            Navigator = new Navigator(webDriver);
        }

        IWebDriver StartUpWebDriver()
        {
            var webdDriver = new ChromeDriver();
            webdDriver.Manage().Window.Maximize();
            return webdDriver;
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
    }
}
