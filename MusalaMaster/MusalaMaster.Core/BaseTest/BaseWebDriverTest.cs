using MusalaMaster.Core.Factories;
using MusalaMaster.Core.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace MusalaMaster.Core.Tests
{
    [TestFixture]
    public abstract class BaseWebDriverTest
    {
        protected static HomePage _homePage;
        protected static SignInPage _signInPage;
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
    }
}