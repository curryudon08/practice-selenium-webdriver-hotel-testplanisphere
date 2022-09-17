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

        [Fact(DisplayName = "登録済みユーザーの情報が表示されること", Skip="スキップ")]
        public void TestExistsUserPattern1()
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

        [Fact(DisplayName = "登録済みユーザーの情報が表示されること", Skip="スキップ")]
        public void estExistsUserPattern2()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("sakura@example.com", "pass1234");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
            Assert.Equal("sakura@example.com", myPage.GetEmailAddress()) ;
            Assert.Equal("松本さくら", myPage.GetUserName()) ;
            Assert.Equal("一般会員", myPage.GetRank()) ;
            Assert.Equal("神奈川県横浜市鶴見区大黒ふ頭", myPage.GetAddress()) ;
            Assert.Equal("未登録", myPage.GetTelephoneNumber()) ;
            Assert.Equal("女性", myPage.GetGender()) ;
            Assert.Equal("2000年4月1日", myPage.GetBirthday()) ;
            Assert.Equal("受け取らない", myPage.GetNotification()) ;
        }

        [Fact(DisplayName = "登録済みユーザーの情報が表示されること", Skip="スキップ")]
        public void estExistsUserPattern3()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("jun@example.com", "pa55w0rd!");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
            Assert.Equal("jun@example.com", myPage.GetEmailAddress()) ;
            Assert.Equal("林潤", myPage.GetUserName()) ;
            Assert.Equal("プレミアム会員", myPage.GetRank()) ;
            Assert.Equal("大阪府大阪市北区梅田", myPage.GetAddress()) ;
            Assert.Equal("01212341234", myPage.GetTelephoneNumber()) ;
            Assert.Equal("その他", myPage.GetGender()) ;
            Assert.Equal("1988年12月17日", myPage.GetBirthday()) ;
            Assert.Equal("受け取らない", myPage.GetNotification()) ;
        }

        [Fact(DisplayName = "登録済みユーザーの情報が表示されること", Skip="スキップ")]
        public void estExistsUserPattern4()
        {
            var toppage = new TopPage(this.driver);
            var loginpage = toppage.GoLoginPage();
            var myPage = loginpage.DoLogin("yoshiki@example.com", "pass-pass");
            Assert.Equal("マイページ", myPage.GetHeaderText()) ;
            Assert.Equal("yoshiki@example.com", myPage.GetEmailAddress()) ;
            Assert.Equal("木村良樹", myPage.GetUserName()) ;
            Assert.Equal("一般会員", myPage.GetRank()) ;
            Assert.Equal("未登録", myPage.GetAddress()) ;
            Assert.Equal("01298765432", myPage.GetTelephoneNumber()) ;
            Assert.Equal("未登録", myPage.GetGender()) ;
            Assert.Equal("1992年8月31日", myPage.GetBirthday()) ;
            Assert.Equal("受け取る", myPage.GetNotification()) ;
        }
    }
}
