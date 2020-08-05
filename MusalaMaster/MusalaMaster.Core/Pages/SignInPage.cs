using Microsoft.Extensions.Configuration;
using MusalaMaster.Core.Models;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver, IConfiguration configuration)
            : base(driver, configuration)
        {
        }

        public override string UrlPart => "login";

        public IWebElement Username => WaitForElementPresent(By.Id("login-form_username"));

        public IWebElement Password => Driver.FindElement(By.Id("login-form_password"));

        public IWebElement StateMessage => WaitForElementPresent(By.XPath("//*[@id='login-form']/div/div[2]/p"));

        public IWebElement SignInButton => Driver.FindElement(By.Id("btn-sign-in"));

        public void FillForm(SignInModel userCreditential)
        {
            Username.SendKeys(userCreditential.Username);
            Password.SendKeys(userCreditential.Password);
        }

        public void Submit()
        {
            SignInButton.Click();
        }

        public void AssertStateMessage()
        {
            Assert.AreEqual("Wrong user or password.", StateMessage.Text);
        }
    }
}
