using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class TopPage : Page
    {
        public static readonly string BaseURL = "https://hotel.testplanisphere.dev/ja/";

        [FindsBy(How = How.LinkText, Using = "ホーム")]
        private readonly IWebElement homeLink;

        [FindsBy(How = How.LinkText, Using = "宿泊予約")]
        private readonly IWebElement reserveLink;

        [FindsBy(How = How.LinkText, Using = "会員登録")]
        private readonly IWebElement signinLink;

        [FindsBy(How = How.LinkText, Using = "ログイン")]
        private readonly IWebElement loginLink;

        public TopPage(WebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
        }

        override protected bool AtPage()
        {
            return  this.driver.Title.Equals("HOTEL PLANISPHERE - テスト自動化練習サイト");
        }

        public LoginPage GoLoginPage()
        {
            this.loginLink.Click();
            return new LoginPage(this.driver);
        }
    }
}
