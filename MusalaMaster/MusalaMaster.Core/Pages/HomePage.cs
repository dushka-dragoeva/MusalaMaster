using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, IConfiguration configuration)
            : base(driver, configuration)
        {
        }

        public IWebElement SignInLink => Driver.FindElement(By.LinkText("Sign In"));

        public IWebElement ArchiveLink => WaitForElementPresent(By.LinkText("Archive"));

        public IWebElement MusalaSoftLink => Driver.FindElement(By.CssSelector("[src='/images/Musala-logo.png']"));

        public IWebElement FacebookLink => Driver.FindElement(By.CssSelector("[src='/images/icon_facebook.png']"));
    }
}
