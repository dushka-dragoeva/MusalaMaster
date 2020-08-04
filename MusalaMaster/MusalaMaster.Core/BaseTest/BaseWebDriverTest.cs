using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace MusalaMaster.Core.Tests
{
    [TestFixture]
    public abstract class BaseWebDriverTest
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private TestContext testContextInstance;

        public virtual TestContext TestContextInstance
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public IWebDriver Driver { get; set; }

       
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}