using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Pages
{
    public class MusalaSoftPage : BasePage
    {
        public MusalaSoftPage(IWebDriver driver, IConfiguration configuration)
            : base(driver, configuration)
        {
        }

        public override string Url => "http://www.musala.com/";
    }
}
