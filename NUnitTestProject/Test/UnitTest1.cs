using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NUnitTestProject

{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
             driver = new ChromeDriver(@"C:\Work");

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();

            
        }

        [Test]
        [TestCaseSource(typeof(TestDataClass), "TestCases")]
        public void CreatenValidate(string code, string description)
            {
            //Creating instance of Administration and Time & Material
                         
                Home HomePage = new Home(driver);
                HomePage.ClickAdministration();
                HomePage.ClickTimenMaterial();


                Record turnupOptions = new Record(driver);
                turnupOptions.CreateNew();
                turnupOptions.CreateNewRecord(code,description);
                turnupOptions.ValidateRecord();
            
        }

        [Test]
        public void EditnValidate()
        {
            //Creating instance of Administration and Time & Material
            var homePage = new Home(driver);
            homePage.ClickAdministration();
            homePage.ClickTimenMaterial();


            Record turnupOptions = new Record(driver);
            turnupOptions.EditRecord();
            //turnupOptions.ValidateRecord();
        }

        [Test]
        public void DeletenValidate()
        {
            //Creating instance of Administration and Time & Material
            var homePage = new Home(driver);
            homePage.ClickAdministration();
            homePage.ClickTimenMaterial();


            Record turnupOptions = new Record(driver);
            turnupOptions.DeleteRecord();

         }
         
        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

    }
    }