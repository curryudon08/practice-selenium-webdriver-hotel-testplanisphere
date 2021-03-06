using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "email")]
        private readonly IWebElement emailForm;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement passwordForm;

        [FindsBy(How = How.Id, Using = "login-button")]
        private readonly IWebElement loginButton;

        [FindsBy(How = How.Id, Using = "email-message")]
        private readonly IWebElement emailMessage;

        [FindsBy(How = How.Id, Using = "password-message")]
        private readonly IWebElement passwordMessage;

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
            this.emailForm.Clear();
            this.emailForm.SendKeys(email);
        }

        public void TypePassword(string password)
        {
            this.passwordForm.Clear();
            this.passwordForm.SendKeys(password);
        }

        public void ClickLogin()
        {
            this.loginButton.Click();
        }

        public string GetEmailMessage()
        {
            return this.emailMessage.Text;
        }

        public string GetPassWordMessage()
        {
            return this.passwordMessage.Text;
        }
    }
}
