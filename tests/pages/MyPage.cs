using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class MyPage : Page
    {
        [FindsBy(How = How.TagName, Using = "h2")]
        private readonly IWebElement headerText;

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
    }
}
