using System;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ConsoleApp1
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void VerifyHomePage()
        {
            // Check whether hello hari is displayed on the page
            IWebElement username = driver.FindElement(By.XPath("//a[contains(.,'Hello hari!')]"));
            Assert.IsTrue(username.Text == "Hello hari!");
        }

        internal void ClickAdminstration()
        {
            // Click adminstration 
            driver.FindElement(By.XPath("//a[contains(.,'Administration')]")).Click();
        }

        internal void ClickTimenMaterial()
        {
            // Click Time n Material 
            driver.FindElement(By.XPath("//a[contains(.,'Time & Materials')]")).Click();
        }
    }
}