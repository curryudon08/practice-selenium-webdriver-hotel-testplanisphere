using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    abstract public class Page
    {
        protected readonly WebDriver driver;

        [FindsBy(How = How.LinkText, Using = "ホーム")]
        protected readonly IWebElement homeLink;

        [FindsBy(How = How.LinkText, Using = "宿泊予約")]
        protected readonly IWebElement reserveLink;

        [FindsBy(How = How.LinkText, Using = "会員登録")]
        protected readonly IWebElement signupLink;

        [FindsBy(How = How.LinkText, Using = "ログイン")]
        protected readonly IWebElement loginLink;

        [FindsBy(How = How.Id, Using = "logout-form")]
        protected readonly IWebElement logoutButton;

        public Page(WebDriver driver)
        {
            this.driver = driver;
            if(!this.AtPage()){
                throw new Exception(string.Join("指定した画面に遷移できません:{0}",this.ToString()));
            }
        }

        abstract protected bool AtPage();
    }
}
