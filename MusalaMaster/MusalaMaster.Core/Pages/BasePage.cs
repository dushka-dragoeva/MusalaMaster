using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace MusalaMaster.Core.Pages
{
    public class BasePage
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver;

        public virtual string Url { get; }

        public virtual string Title { get; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            Driver.Manage().Window.Maximize();
            EnsurePageLoaded();
        }

        private WebDriverWait Wait(int timeSpanSeconds) => new WebDriverWait(Driver, TimeSpan.FromSeconds(timeSpanSeconds));

        // TODO read timeout from config file
        protected IWebElement WaitForElementPresent(By by, int timeout = 10)
        {
            IWebElement result = null;
            try
            {
                result = Wait(timeout).Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                log.Error(ex.Message);
                throw new NoSuchElementException($"{by}", ex);
            }

            return result;
        }

        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = Driver.Url.StartsWith(Url);
            }
            else
            {
                urlIsCorrect = Driver.Url == Url;
            }

            bool pageHasLoaded = urlIsCorrect && (Driver.Title == Title);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }
    }
}
