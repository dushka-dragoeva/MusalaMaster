using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace MusalaMaster.Core.Pages
{
    public class ArchivePage : BasePage
    {
        public ArchivePage(IWebDriver driver)
            : base(driver)
        {
        }

        public override string UrlPart => "archive";

       public IWebElement LastEvent => WaitForElementsPresent(By.XPath("//*[@id='events-cont']//*[@class='event-magnifier']")).Last();
        
        public void ScrollDown()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(LastEvent);
            actions.Perform();
        }
    }
}
