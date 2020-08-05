using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Models;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.BaseTests;
using MusalaMaster.GUITests.Utils;

namespace MusalaMaster.GUITests.Tests
{
    [Parallelizable]
    [TestFixture]
    public class SignInTestsWithParameters : TestHook
    {
        private SignInPage _signInPage;

        [SetUp]
        public override void SetupTest()
        {
            bool isChrome = Configuration["defaultDriver"] == "Chrome";
            bool isFirefox = Configuration["defaultDriver"] == "Firefox";

            if (isChrome)
            {
                Driver = new ChromeDriver();
            }
            else if (isFirefox)
            {
                Driver = new FirefoxDriver();
            }
            else
            {
                throw new NotImplementedException($"{Configuration["defaultDriver"]} is not supportet for testing");
            }

            _homePage = new HomePage(Driver, Configuration);
            _homePage.NavigateTo();
            _signInPage = new SignInPage(Driver, Configuration);
        }

        [Test]
        [TestCaseSource(typeof(TestCasesGenarotor), "GenerateSignInTestCases", new object[] { "invalid_user_creditentials.csv" })]
        public void StateMessageAppeared_When_SignInWithInvalidCreditentials(string username, string password)
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
