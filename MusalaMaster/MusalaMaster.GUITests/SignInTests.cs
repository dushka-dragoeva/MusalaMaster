using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Models;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.Tests;
using MusalaMaster.GUITests.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace MusalaMaster.UITests.Tests
{
    [TestFixture]
    public class SignInTests : BaseWebDriverTest
    {
        private static HomePage _homePage;
        private static SignInPage _signInPage;

        [SetUp]
        public void SetupTest()
        {
            // TODO with DI and settings
            Driver = new FirefoxDriver();
           /// Driver = new ChromeDriver();

            _homePage = new HomePage(Driver);
            _homePage.NavigateTo();
            _signInPage = new SignInPage(Driver);
        }

        [Test]
        [TestCaseSource(typeof(TestCasesGenarotor), "GenerateSignInTestCases", new object[] { "invalid_user_creditentials.csv" })]
        public void StateMessageAppeared_When_SignInWithInvalidCreditentials3(string username, string password)
        {
            SignInModel userCreditentials = SignInFactory.CreateModel(username, password);

            _homePage.SignInLink.Click();
            _signInPage.EnsurePageLoaded();
            _signInPage.FillForm(userCreditentials);
            _signInPage.Submit();

            _signInPage.AssertStateMessage();
        }
    }
}
