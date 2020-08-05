using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class MusalaSoftPage : BasePage
    {
        public MusalaSoftPage(IWebDriver driver)
            : base(driver)
        {
        }

        public override string Url => "http://www.musala.com/";
    }
}
