using System.Collections.Generic;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) 
            :base(driver)
        {
        }

        public IWebElement SignInLink => Driver.FindElement(By.LinkText("Sign In"));

        public IWebElement ArchiveLink => Driver.FindElement(By.LinkText("Archive"));

        public IWebElement MusalaSoftLink => Driver.FindElement(By.CssSelector("[src='/images/Musala-logo.png']"));

        public IWebElement FacebookLink => Driver.FindElement(By.CssSelector("[src='/images/icon_facebook.png']"));
    }
}
