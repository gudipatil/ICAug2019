using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestFixture]
    class TMTests
    {
        static void Main(string[] args)
        {     

        }
        IWebDriver driver;
        [SetUp]
        public void BeforeEachTestCase()
        {
            // Browser initiate 
            driver = new ChromeDriver();

            //navigate to horse-dev
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //maximize t
            driver.Manage().Window.Maximize();

            // access loginsucess method 
            // an instance of class
            LoginPage loginInstance = new LoginPage(driver);
            loginInstance.LoginSuccess();
        }

        [TearDown]
        public void AfterEachTestCase()
        {
            // Close the driver
            driver.Quit();
        }
        
        [Test]
        public void CreateTMnValidate()
        {
            string typecode = "Material";
            string code = "ICAug19";
            string description = "Selenium Training";
            string price = "$155.00";
            HomePage homeInstance = new HomePage(driver);
            homeInstance.VerifyHomePage();
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();

            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            tmPage.ClickCreateNew();
            tmPage.EnterValidDataandSave(typecode, code, description, price);
            Assert.IsTrue("RecordFound" == tmPage.ValidateData(typecode, code, description, price), "Created record not found");
        }

        [Test]
        public void EditnValidate()
        {            
            HomePage homeInstance = new HomePage(driver);
            homeInstance.VerifyHomePage();
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();
            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            string result = tmPage.EditValidDataandSave("Material", "ICAug19", "Selenium Training", "$155.00", "Time", "ICAug19_edit", "Selenium Training Edit", "$200");
            Assert.IsTrue("success" == result, "Edit failed");
            Assert.IsTrue("RecordFound" == tmPage.ValidateData("Time", "ICAug19_edit", "Selenium Training Edit", "$200.00"), "Validate failed");
        }

        [Test]
        public void DeletenValidate()
        {
            HomePage homeInstance = new HomePage(driver);
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();
            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            Assert.IsTrue("success" == tmPage.DeleteData("Material", "ICAug19", "Selenium Training", "$155.00", "ok"), "Delete Failed");
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();
            Assert.IsFalse("RecordFound"== tmPage.ValidateData("Material", "ICAug19", "Selenium Training", "$155.00"), "Validate Failed");
        }
    }
}
