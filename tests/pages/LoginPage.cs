using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "email")]
        private readonly IWebElement emailTextArea;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement passwordTextArea;

        [FindsBy(How = How.Id, Using = "login-button")]
        private readonly IWebElement submitButton;

        public LoginPage(WebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
        }

        override protected bool AtPage()
        {
            return  this.driver.Title.StartsWith("ログイン");
        }

        public MyPage DoLogin(string email, string password)
        {
            this.TypeEmail(email);
            this.TypePassword(password);
            this.ClickLogin();
            return new MyPage(this.driver);
        }

        public void TypeEmail(string email)
        {
            this.emailTextArea.Clear();
            this.emailTextArea.SendKeys(email);
        }

        public void TypePassword(string password)
        {
            this.passwordTextArea.Clear();
            this.passwordTextArea.SendKeys(password);
        }

        public void ClickLogin()
        {
            this.submitButton.Click();
        }
    }
}
