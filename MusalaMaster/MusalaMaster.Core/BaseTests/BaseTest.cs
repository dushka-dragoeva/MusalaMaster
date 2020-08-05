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
    }
}