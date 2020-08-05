using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Models;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.Tests;
using MusalaMaster.GUITests.Utils;
using NUnit.Framework;

namespace MusalaMaster.UITests.Tests
{
    [TestFixture]
    public class SignInTests : BaseTest
    {
        private static SignInPage _signInPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _signInPage = new SignInPage(Driver);
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
