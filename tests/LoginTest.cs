using System;
using Xunit;
using OpenQA.Selenium;
using tests.utils;
using tests.pages;
using SeleniumExtras.PageObjects;

namespace tests
{
    [Collection("Test Collection #1")]
    public class LoginTest:IDisposable
    {
        private WebDriver driver;

        public LoginTest()
        {
            this.driver = Utility.CreateWebDriver();
            driver.Url = TopPage.BaseURL;
        }

        [Fact]
        public void TestLoginSuccess()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
        }

        public void Dispose()
        {
            this.driver.Quit();
        }
    }
}
