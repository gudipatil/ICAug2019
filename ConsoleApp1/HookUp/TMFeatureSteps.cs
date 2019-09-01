using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ConsoleApp1.Utilities;

namespace ConsoleApp1.HookUp
{
    [Binding]
    public class TMFeatureSteps
    {
        IWebDriver driver;
        [Given(@"I have logged into the turn up portal")]
        public void GivenIHaveLoggedIntoTheTurnUpPortal()
        {
            // Browser initiate 
            driver = new ChromeDriver();

            //navigate to horse-dev
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //maximize t
            driver.Manage().Window.Maximize();

            //access loginsucess method 
            // an instance of class
            LoginPage loginInstance = new LoginPage(driver);
            loginInstance.LoginSuccess();
        }

        [Given(@"I have navigate to the time and material page")]
        public void GivenIHaveNavigateToTheTimeAndMaterialPage()
        {
            HomePage homeInstance = new HomePage(driver);
            homeInstance.VerifyHomePage();
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();
            Console.WriteLine("navigation success");
        }

        [Then(@"I should be able to create a time and material record\.")]
        public void ThenIShouldBeAbleToCreateATimeAndMaterialRecord_()
        {
            ExcelReader.PopulateInCollection("Create");
            string typecode = ExcelReader.ReadData(2, "TypeCode");
            string code = ExcelReader.ReadData(2, "Code");
            string description = ExcelReader.ReadData(2, "Description");
            string price = ExcelReader.ReadData(2, "PricePerUnit");
            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            tmPage.ClickCreateNew();
            tmPage.EnterValidDataandSave(typecode, code, description, price);
            Assert.IsTrue("RecordFound" == tmPage.ValidateData(typecode, code, description, "$"+price), "Created record not found");
            driver.Quit();
        }

        [Then(@"I should be able to delete a time and material record\.")]
        public void ThenIShouldBeAbleToDeleteATimeAndMaterialRecord_()
        {
            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            HomePage homeInstance = new HomePage(driver);
            
            // Reads data from the excel file with sheetname "Delete"
            ExcelReader.PopulateInCollection("Delete");
            string typecode = ExcelReader.ReadData(2, "TypeCode");
            string code = ExcelReader.ReadData(2, "Code");
            string description = ExcelReader.ReadData(2, "Description");
            string price = ExcelReader.ReadData(2, "PricePerUnit");
                       
            tmPage.ClickCreateNew();
            tmPage.EnterValidDataandSave(typecode, code, description, price);
            tmPage.DeleteData(typecode, code, description, "$"+price);
           
            // Verifies if the record is deleted
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();
            Assert.IsTrue("RecordNotFound" == tmPage.ValidateData(typecode, code, description, "$"+price), "Validate Failed");
            driver.Quit();
        }

        [Then(@"I should be able to edit a time and material record\.")]
        public void ThenIShouldBeAbleToEditATimeAndMaterialRecord_()
        {
            HomePage homeInstance = new HomePage(driver);
            homeInstance.VerifyHomePage();
            homeInstance.ClickAdminstration();
            homeInstance.ClickTimenMaterial();

            // Convert excel data in "Edit" sheet into tables
            ExcelReader.PopulateInCollection("Edit");
            string typecode = ExcelReader.ReadData(2, "TypeCode");
            string code = ExcelReader.ReadData(2, "Code");
            string description = ExcelReader.ReadData(2, "Description");
            string price = ExcelReader.ReadData(2, "PricePerUnit");
            string newtypecode = ExcelReader.ReadData(2, "NewTypeCode");
            string newcode = ExcelReader.ReadData(2, "NewCode");
            string newdescription = ExcelReader.ReadData(2, "NewDescription");
            string newprice = ExcelReader.ReadData(2, "NewPrice");

            Console.WriteLine(typecode + code + description + price + newtypecode + newdescription + newprice);

            TimenMaterialPage tmPage = new TimenMaterialPage(driver);
            string result = tmPage.EditValidDataandSave(typecode, code, description, "$"+price, newtypecode, newcode, newdescription, newprice);
            Assert.IsTrue("success" == result, "Edit failed");
            Assert.IsTrue("RecordFound" == tmPage.ValidateData(newtypecode, newcode, newdescription, "$"+newprice), "Validate failed");
            driver.Quit();
        }
    }
}
