using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConsoleApp1.Utilities
{
    class Wait
    {
        public static IWebElement ElementIsVisible(IWebDriver driver, string value, int seconds=5)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
            return element;
        }

    }
}
