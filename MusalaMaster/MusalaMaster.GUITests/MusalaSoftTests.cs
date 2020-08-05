using MusalaMaster.Core.Helpers;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.Tests;
using NUnit.Framework;

namespace MusalaMaster.GUITests
{
    [TestFixture]
    public class MusalaSoftTests : BaseTest
    {
        private MusalaSoftPage _musalaSoftPage;
        private MuffinConferenceFacebookPage _muffinConferenceFacebookPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _musalaSoftPage = new MusalaSoftPage(Driver);
            _muffinConferenceFacebookPage = new MuffinConferenceFacebookPage(Driver);
        }

        [Test]
        public void StateMessageAppeared_When_SignInWithInvalidCreditentials()
        {
            var config = ConfigurationHelper.GetIConfigurationRoot();
            bool isChromDriver = config["defaultDriver"] == "Chrome";

            _homePage.MusalaSoftLink.Click();
            SwitchToTab(1);

            _musalaSoftPage.EnsurePageLoaded();

            SwitchToTab(0);
            _homePage.FacebookLink.Click();
            if (isChromDriver)
            {
                SwitchToTab(2);
            }
            else
            {
                SwitchToTab(1);
            }

            _muffinConferenceFacebookPage.EnsurePageLoaded();
            _muffinConferenceFacebookPage.EnsureProfilePictureExist();
        }
    }
}
