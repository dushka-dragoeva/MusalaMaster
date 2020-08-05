using NUnit.Framework;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.BaseTests;

namespace MusalaMaster.GUITests.Tests
{
    [Parallelizable]
    [TestFixture]
    public class ArchiveTests : TestHook
    {
        private ArchivePage _archivePage;
        private EventPage _eventPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _archivePage = new ArchivePage(Driver, Configuration);
            _eventPage = new EventPage(Driver, Configuration);
        }

        [Test]
        public void PrintLastEventContent()
        {
            _homePage.ArchiveLink.Click();

            _archivePage.EnsurePageLoaded();

            _archivePage.ScrollDown();
            _archivePage.LastEvent.Click();

            _eventPage.PrintEventContent();
        }
    }
}
