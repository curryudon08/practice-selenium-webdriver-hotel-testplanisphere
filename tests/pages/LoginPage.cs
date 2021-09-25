using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace tests.pages
{
    public class LoginPage : Page
    {
        public LoginPage(WebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
        }

        override protected bool AtPage()
        {
            return  this.driver.Title.StartsWith("ログイン");
        }
    }
}
