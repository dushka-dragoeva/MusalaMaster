using NUnit.Framework;
using MusalaMaster.Core.Pages;
using MusalaMaster.Core.BaseTests;

namespace MusalaMaster.GUITests
{
    [TestFixture]
    public class ArchiveTests : BaseTest
    {
        private static ArchivePage _archivePage;
        private EventPage _eventPage;

        [SetUp]
        public override void SetupTest()
        {
            base.SetupTest();
            _archivePage = new ArchivePage(Driver);
            _eventPage = new EventPage(Driver);
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
