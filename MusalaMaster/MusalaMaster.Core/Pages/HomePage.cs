using MusalaMaster.Core.Pages;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) :
            base(driver)
        {
        }

        public override string Url => "https://masters.musala.com/";

        public override string Title => "Meet the Masters";

        public IWebElement SignInLink => Driver.FindElement(By.LinkText("Sign In"));

        public IWebElement Archive => Driver.FindElement(By.LinkText("Archive"));

        public IWebElement MusalaSoftLink => WaitForElementPresent(By.CssSelector("[src='/images/Musala-logo.png']"));
    }
}
