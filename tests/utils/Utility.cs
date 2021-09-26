using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace tests.utils
{
    public class Utility
    {
        private static readonly string EdgeWebDriverPath = "D:\\edgedriver_win64";

        private Utility()
        {
        }

        public static WebDriver CreateWebDriver()
        {
            //Chromium版Edgeを使用する
            var options = new EdgeOptions();
            options.UseChromium = true;

            var driver = new EdgeDriver(Utility.EdgeWebDriverPath, options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
