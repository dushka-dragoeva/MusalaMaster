using NUnit.Framework;
using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Models;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.BaseTests;

namespace MusalaMaster.GUITests.Tests
{
    [Parallelizable]
    [TestFixture]
    public class SignInTests : TestHook
    {
        private SignInPage _signInPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _signInPage = new SignInPage(Driver, Configuration);
        }

        [Test]
        public void StateMessageAppeared_When_SignInWithInvalidCreditentials()
        {
            SignInModel userCreditentials = SignInFactory.CreateModel("Pepi", "12345");

            _homePage.SignInLink.Click();

            _signInPage.EnsurePageLoaded();

            _signInPage.FillForm(userCreditentials);
            _signInPage.Submit();

            _signInPage.AssertStateMessage();
        }
    }
}
