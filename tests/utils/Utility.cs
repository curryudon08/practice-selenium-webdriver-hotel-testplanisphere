using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace tests.utils
{
    public class Utility
    {
        private static readonly string WebDriverPath = "D:\\tool\\edgedriver_win64";

        private Utility()
        {
        }

        public static WebDriver CreateWebDriver()
        {
            //Chromium版Edgeを使用する
            var options = new EdgeOptions();
            options.UseChromium = true;

            var driver = new EdgeDriver(WebDriverPath, options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
