using System;
using MusalaMaster.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace MusalaMaster.Core.Factories
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            var config = ConfigurationHelper.GetIConfigurationRoot();
            if (config["defaultDriver"] == "Chrome")
            {
                 return new ChromeDriver();
            }
            else if (config["defaultDriver"] == "Firefox")
            {
                return new FirefoxDriver();
            }
            else
            {
                throw new NotImplementedException($" Browser {config["defaultDriver"]} is not supportet for testing");
            }
        }
    }
}
