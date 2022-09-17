using System;
using Xunit;
using Xunit.Abstractions;
using OpenQA.Selenium;
using tests.utils;
using tests.pages;

namespace tests
{
    [Collection("Test Collection #1")]
    public class SignupTest:IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        private readonly WebDriver driver;

        public SignupTest(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            this.driver = Utility.CreateWebDriver();
            driver.Url = TopPage.BaseURL;
        }

        public void Dispose()
        {
            this.driver.Manage().Cookies.DeleteAllCookies();
            this.driver.Quit();
        }

        [Fact(DisplayName = "入力必須箇所を未入力で登録できないこと")]
        public void TestLoginFailBlank()
        {
            var toppage = new TopPage(this.driver);
            var signuppage = toppage.GoSignupPage();
            signuppage.ClickRegister();
            Assert.Equal("このフィールドを入力してください。", signuppage.GetEmailMessage());
            Assert.Equal("このフィールドを入力してください。", signuppage.GetPasswordMessage());
            Assert.Equal("このフィールドを入力してください。", signuppage.GetPasswordConfirmationMessage());
            Assert.Equal("このフィールドを入力してください。", signuppage.GetNameMessage());
        }
    }
}
