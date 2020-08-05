using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using MusalaMaster.Core.Pages;

namespace MusalaMaster.Core.BaseTests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected HomePage _homePage;

        public IWebDriver Driver { get; set; }
        public IConfiguration Configuration { get; set; }

        [SetUp]
        public virtual void SetupTest()
        {
            _homePage = new HomePage(Driver, Configuration);
            _homePage.NavigateTo();
        }

        [TearDown]
        public virtual void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void SwitchToTab(int tabIndex) => Driver.SwitchTo().Window(Driver.WindowHandles[tabIndex]);
    }
}