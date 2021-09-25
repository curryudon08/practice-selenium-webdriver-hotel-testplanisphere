using System;
using OpenQA.Selenium;

namespace tests.pages
{
    abstract public class Page
    {
        protected readonly WebDriver driver;

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
