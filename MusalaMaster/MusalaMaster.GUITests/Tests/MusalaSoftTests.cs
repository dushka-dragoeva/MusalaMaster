using NUnit.Framework;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.BaseTests;

namespace MusalaMaster.GUITests.Tests
{
    [Parallelizable]
    [TestFixture]
    public class MusalaSoftTests : TestHook
    {
        private MusalaSoftPage _musalaSoftPage;
        private MuffinConferenceFacebookPage _muffinConferenceFacebookPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _musalaSoftPage = new MusalaSoftPage(Driver, Configuration);
            _muffinConferenceFacebookPage = new MuffinConferenceFacebookPage(Driver, Configuration);
        }

        [Test]
        public void CorectPagesOpenedAndProfilePictureDisplayed_When_ClickCorespondingLinks()
        {
            bool isChromDriver = Configuration["defaultDriver"] == "Chrome";

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
