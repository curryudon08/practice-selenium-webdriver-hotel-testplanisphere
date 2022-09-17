using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class SignupPage : Page
    {
        [FindsBy(How = How.TagName, Using = "h2")]
        private readonly IWebElement headerText;

        [FindsBy(How = How.Id, Using = "email")]
        private readonly IWebElement emailForm;

        [FindsBy(How = How.Id, Using = "password")]
        private readonly IWebElement passwordForm;

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        private readonly IWebElement passwordConfirmationForm;

        [FindsBy(How = How.Id, Using = "username")]
        private readonly IWebElement usernameForm;

        [FindsBy(How = How.Id, Using = "address")]
        private readonly IWebElement addressForm;

        [FindsBy(How = How.Id, Using = "tel")]
        private readonly IWebElement telephoneForm;

        [FindsBy(How = How.Id, Using = "gender")]
        private readonly IWebElement genderForm;

        [FindsBy(How = How.Id, Using = "birthday")]
        private readonly IWebElement birthdayForm;

        [FindsBy(How = How.Id, Using = "notification")]
        private readonly IWebElement notificationForm;

        [FindsBy(How = How.CssSelector, Using = "#signup-form > button")]
        private readonly IWebElement registerButton;

        [FindsBy(How = How.CssSelector, Using = "#signup-form > div:nth-child(1) > div")]
        private readonly IWebElement emailMessage;

        [FindsBy(How = How.CssSelector, Using = "#signup-form > div:nth-child(2) > div")]
        private readonly IWebElement passwordMessage;

        [FindsBy(How = How.CssSelector, Using = "#signup-form > div:nth-child(3) > div")]
        private readonly IWebElement passwordConfirmationMessage;

        [FindsBy(How = How.CssSelector, Using = "#signup-form > div:nth-child(4) > div")]
        private readonly IWebElement nameMessage;

        public SignupPage(WebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
        }

        override protected bool AtPage()
        {
            return  this.driver.Title.StartsWith("会員登録");
        }

        public String GetHeaderText()
        {
            return this.headerText.Text;
        }

        public string GetEmailMessage()
        {
            return this.emailMessage.Text;
        }

        public string GetPasswordMessage()
        {
            return this.passwordMessage.Text;
        }

        public string GetPasswordConfirmationMessage()
        {
            return this.passwordConfirmationMessage.Text;
        }

        public string GetNameMessage()
        {
            return this.nameMessage.Text;
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

        public void TypePasswordConfirmation(string passwordConfirmation)
        {
            this.passwordConfirmationForm.Clear();
            this.passwordConfirmationForm.SendKeys(passwordConfirmation);
        }

        public void TypeUserName(string username)
        {
            this.usernameForm.Clear();
            this.usernameForm.SendKeys(username);
        }

        public void TypeAddress(string address)
        {
            this.addressForm.Clear();
            this.addressForm.SendKeys(address);
        }

        public void ChoiseRank(string rank)
        {

        }

        public void TypeTelephone(string telephone)
        {
            this.telephoneForm.Clear();
            this.telephoneForm.SendKeys(telephone);
        }

        public void ChoiseGender(string gender)
        {

        }

        public void TypeBirthday(string birthday)
        {
        }

        public void ChoiseNotification(string notification)
        {

        }

        public void ClickRegister()
        {
            this.registerButton.Click();
        }
    }
}
