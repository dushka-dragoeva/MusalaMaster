﻿using System;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using MusalaMaster.Core.Pages;

namespace MusalaMaster.Core.BaseTests
{
    [TestFixture]
    public class TestHook : BaseTest
    {
        public TestHook()
        {
            Configuration = GetConfiguration();
            bool isChrome = Configuration["defaultDriver"] == "Chrome";
            bool isFirefox = Configuration["defaultDriver"] == "Firefox";

            if (isChrome)
            {
                Driver = new ChromeDriver();
            }
            else if (isFirefox)
            {
                Driver = new FirefoxDriver();
            }
            else
            {
                throw new NotImplementedException($"{Configuration["defaultDriver"]} is not supportet for testing");
            }
        }

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

        private IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
            return config;

        }
    }
}
