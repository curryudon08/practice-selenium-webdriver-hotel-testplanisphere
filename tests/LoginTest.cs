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
            this.driver.Manage().Cookies.DeleteAllCookies();
            this.driver.Quit();
        }

        [Theory(DisplayName = "登録済みのユーザーでログインできること")]
        [CsvData("../../../../testdata/logintest1.csv")]
        public void TestLoginSuccess(string email, string password)
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin(email, password);
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
        }

        [Theory(DisplayName = "未登録のユーザーでログインできないこと")]
        [CsvData("../../../../testdata/logintest2.csv")]
        public void TestLoginFailUnregister(string email, string password)
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            loginpage.TypeEmail(email);
            loginpage.TypePassword(password);
            loginpage.ClickLogin();
            Assert.Equal("メールアドレスまたはパスワードが違います。", loginpage.GetEmailMessage());
            Assert.Equal("メールアドレスまたはパスワードが違います。", loginpage.GetPassWordMessage());
        }

        [Fact(DisplayName = "未入力でログインできないこと")]
        public void TestLoginFailBlank()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            loginpage.TypeEmail("");
            loginpage.TypePassword("");
            loginpage.ClickLogin();
            Assert.Equal("このフィールドを入力してください。", loginpage.GetEmailMessage());
            Assert.Equal("このフィールドを入力してください。", loginpage.GetPassWordMessage());
        }
    }
}
