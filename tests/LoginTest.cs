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

        [Fact(DisplayName = "登録済みのユーザーでログインできること")]
        public void TestLoginSuccess()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("ichiro@example.com", "password");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
        }

        [Fact(DisplayName = "未登録のユーザーでログインできないこと")]
        public void TestLoginFailUnregister()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            loginpage.TypeEmail("hogehoge@example.com");
            loginpage.TypePassword("hogehoge");
            loginpage.ClickLogin();
            var t1 = "メールアドレスまたはパスワードが違います。".Equals(loginpage.GetEmailMessage());
            var t2 = "メールアドレスまたはパスワードが違います。".Equals(loginpage.GetPassWordMessage());
            Assert.True(t1 && t2);
        }

        [Fact(DisplayName = "未入力でログインできないこと")]
        public void TestLoginFailBlank()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            loginpage.TypeEmail("");
            loginpage.TypePassword("");
            loginpage.ClickLogin();
            var t1 = "このフィールドを入力してください。".Equals(loginpage.GetEmailMessage());
            var t2 = "このフィールドを入力してください。".Equals(loginpage.GetPassWordMessage());
            Assert.True(t1 && t2);
        }
    }
}
