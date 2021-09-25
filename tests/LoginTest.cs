using System;
using Xunit;
using Xunit.Abstractions;
using OpenQA.Selenium;
using tests.utils;
using tests.pages;

namespace tests
{
    [Collection("Test Collection #1")]
    public class LoginTest:IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        private readonly WebDriver driver;

        public LoginTest(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            this.driver = Utility.CreateWebDriver();
            driver.Url = TopPage.BaseURL;
        }

        public void Dispose()
        {
            this.driver.Quit();
        }

        [Fact]
        public void TestLoginSuccess()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("ichiro@example.com", "password");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
        }
    }
}
