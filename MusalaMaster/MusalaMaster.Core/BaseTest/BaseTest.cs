using System;
using System.Diagnostics;
using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MusalaMaster.Core.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected static HomePage _homePage;
        public IWebDriver Driver { get; set; }

        [SetUp]
        public virtual void SetupTest()
        {
            Driver = DriverFactory.CreateDriver();
            _homePage = new HomePage(Driver);
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
                Trace.WriteLine(ex.Message);
            }
        }

        protected void SwitchToTab(int tabIndex) => Driver.SwitchTo().Window(Driver.WindowHandles[tabIndex]);
    }
}