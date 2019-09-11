using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using UI.Core.Interfaces;
using NUnit.Framework;

namespace UI.Core
{
    public class PageInterfaceProvider : IDisposable
    {
        private readonly IWebDriver _webDriver;

        public IPageInterface PageInterface { get; }
        public INavigator Navigator { get; }

        public static TimeSpan WaitUntilTimeout => TimeSpan.FromSeconds(60);

        public PageInterfaceProvider()
        {
            _webDriver = StartUpWebDriver();
            PageInterface = new PageInterface(_webDriver);
            Navigator = new Navigator(_webDriver);
        }

        private IWebDriver StartUpWebDriver()
        {
            try
            {
                var driver = new ChromeDriver(TestContext.CurrentContext.WorkDirectory);
                driver.Manage().Window.Maximize();
                return driver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}
