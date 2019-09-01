using ConsoleApp1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement username => driver.FindElement(By.Id("UserName"));
        IWebElement password => driver.FindElement(By.Id("Password"));
        IWebElement loginbtn => driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));

        internal void LoginSuccess()
        {
            ExcelReader.PopulateInCollection("Login");
            string usrname = ExcelReader.ReadData(2, "UserName");
            string pwd = ExcelReader.ReadData(2, "Password");

            string usrcmd = String.Format("document.getElementById('UserName').value = '{0}'", usrname);
            string pwdcmd = String.Format("document.getElementById('Password').value = '{0}'", pwd);
            JSExecutor.JavaScriptExec(driver, usrcmd);
            JSExecutor.JavaScriptExec(driver, pwdcmd);

            loginbtn.Click();
        }
        internal void LoginFailure()
        {
            username.SendKeys("sdfghari");
            password.SendKeys("12sdfsd3123");
            loginbtn.Click();
        }
    }
}
