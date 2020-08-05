using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MusalaMaster.Core.Pages
{
    public class EventPage : BasePage
    {
        public EventPage(IWebDriver driver)
            : base(driver)
        {
        }

        /// public IWebElement EventContent => WaitForElementPresent(By.Id("content"));

        public IEnumerable<IWebElement> EventContent => WaitForElementsPresent(By.XPath("//*[@id='content']/ul"));


        public IEnumerable<string> GetPrintableEventContent()
        {
            var content = new List<string>();
            var count = EventContent.Count();

            foreach (var element in EventContent)
            {
                if (element.Text.Contains("Day"))
                {
                    content.Add(element.Text.Trim());
                }
                else
                {
                    var title = element.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();
                    content.Add(title);
                }
            }

            return content;
        }

        public void PrintEventContent()
        {
            foreach (var element in EventContent)
            {
                if (element.Text.Contains("Day"))
                {
                    Console.WriteLine(element.Text.Trim());
                }
                else
                {
                    var title = element.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Console.WriteLine(title.Trim());
                }
            }
        }
    }
}
