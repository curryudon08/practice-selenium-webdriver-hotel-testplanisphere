using System;
using Xunit;
using Xunit.Abstractions;
using OpenQA.Selenium;
using tests.utils;
using tests.pages;

namespace tests
{
    [Collection("Test Collection #1")]
    public class MyPageTest:IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        private readonly WebDriver driver;

        public MyPageTest(ITestOutputHelper outputHelper)
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

        [Fact(DisplayName = "登録済みユーザーの情報が表示されること")]
        public void TestOriginalExistsUser()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("ichiro@example.com", "password");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
            Assert.Equal("ichiro@example.com", myPage.GetEmailAddress()) ;
            Assert.Equal("山田一郎", myPage.GetUserName()) ;
            Assert.Equal("プレミアム会員", myPage.GetRank()) ;
            Assert.Equal("東京都豊島区池袋", myPage.GetAddress()) ;
            Assert.Equal("01234567891", myPage.GetTelephoneNumber()) ;
            Assert.Equal("男性", myPage.GetGender()) ;
            Assert.Equal("未登録", myPage.GetBirthday()) ;
            Assert.Equal("受け取る", myPage.GetNotification()) ;
        }
    }
}
