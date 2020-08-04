using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using MusalaMaster.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MusalaMaster.Core.Pages
{
    public class BasePage
    {
        // TODO Singlton in seprate class, add sections
        private static IConfiguration _configuration => ConfigurationHelper.GetIConfigurationRoot();
       
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver;

        public string Url => GetUrl(UrlPart, QueryPart);

        public virtual string UrlPart { get; set; }

        public virtual string QueryPart { get; set; }

        public virtual int Timeout => int.Parse(_configuration["elementPresentTimeout"]);

        public virtual string Title => "Meet the Masters";

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            Driver.Manage().Window.Maximize();
            EnsurePageLoaded();
        }

        private WebDriverWait Wait(int timeSpanSeconds) => new WebDriverWait(Driver, TimeSpan.FromSeconds(timeSpanSeconds));

        protected IWebElement WaitForElementPresent(By by)
        {
            IWebElement result = null;
            try
            {
                result = Wait(Timeout).Until(x => x.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                Trace.WriteLine(ex.Message);
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

            bool pageHasLoaded = urlIsCorrect;//&& (Driver.Title == Title);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{Driver.Url}' Page Source: \r\n {Driver.PageSource}");
            }
        }

        private static string GetUrl(string urlPart, string query)
        {
            var builder = new UriBuilder(new Uri(_configuration["baseUrl"]))
            {
                Path = urlPart,
                Query = query,
                Port = -1,
            };

            return builder.ToString();
        }
    }
}
