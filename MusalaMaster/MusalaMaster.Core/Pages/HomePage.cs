using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) :
            base(driver)
        {
        }

        public IWebElement SignInLink => Driver.FindElement(By.LinkText("Sign In"));

        public IWebElement Archive => Driver.FindElement(By.LinkText("Archive"));

        public IWebElement MusalaSoftLink => WaitForElementPresent(By.CssSelector("[src='/images/Musala-logo.png']"));
    }
}
