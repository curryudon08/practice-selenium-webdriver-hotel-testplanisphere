using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class MyPage : Page
    {
        [FindsBy(How = How.TagName, Using = "h2")]
        private readonly IWebElement headerText;

        [FindsBy(How = How.Id, Using = "email")]
        private readonly IWebElement email;

        [FindsBy(How = How.Id, Using = "username")]
        private readonly IWebElement username;

        [FindsBy(How = How.Id, Using = "rank")]
        private readonly IWebElement rank;

        [FindsBy(How = How.Id, Using = "address")]
        private readonly IWebElement address;

        [FindsBy(How = How.Id, Using = "tel")]
        private readonly IWebElement tel;

        [FindsBy(How = How.Id, Using = "gender")]
        private readonly IWebElement gender;

        [FindsBy(How = How.Id, Using = "birthday")]
        private readonly IWebElement birthday;

        [FindsBy(How = How.Id, Using = "notification")]
        private readonly IWebElement notification;

        [FindsBy(How = How.Id, Using = "icon-link")]
        private readonly IWebElement iconButton;

        [FindsBy(How = How.Id, Using = "delete-form")]
        private readonly IWebElement deleteButton;

        public MyPage(WebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
        }

        override protected bool AtPage()
        {
            return  this.driver.Title.StartsWith("マイページ");
        }

        public String GetHeaderText()
        {
            return this.headerText.Text;
        }

        public String GetEmailAddress()
        {
            return this.email.Text;
        }

        public String GetUserName()
        {
            return this.username.Text;
        }

        public String GetRank()
        {
            return this.rank.Text;
        }

        public String GetAddress()
        {
            return this.address.Text;
        }

        public String GetTelephoneNumber()
        {
            return this.tel.Text;
        }

        public String GetGender()
        {
            return this.gender.Text;
        }

        public String GetBirthday()
        {
            return this.birthday.Text;
        }

        public String GetNotification()
        {
            return this.notification.Text;
        }

        public bool IsEnabledIconButon()
        {
            return this.iconButton. Enabled;
        }

        public bool IsEnabledDeleteButon()
        {
            return this.deleteButton.Enabled;
        }
    }
}
