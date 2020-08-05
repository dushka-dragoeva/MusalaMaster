using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace MusalaMaster.Core.Pages
{
    public class ArchivePage : BasePage
    {
        public ArchivePage(IWebDriver driver, IConfiguration configuration)
            : base(driver, configuration)
        {
        }

        public override string UrlPart => "archive";

        public IWebElement LastEvent => WaitForElementsPresent(By.XPath("//*[@id='events-cont']//*[@class='event-magnifier']")).Last();

        public void ScrollDown()
        {
            var javaScriptExecutor = (IJavaScriptExecutor)Driver;
            javaScriptExecutor.ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }
    }
}
