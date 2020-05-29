using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace NUnitTestProject.HookUp
{
    [Binding]
    public class TimenMaterialSteps
    {
        IWebDriver driver;
        [Given(@"I have logged in to the turnup portal successfully")]
        public void GivenIHaveLoggedInToTheTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();

            //Creating instance of Login Page
            var loginPage = new Login(driver);
            loginPage.LoginSuccess();

        }

        [Given(@"I create a time and material")]
        public void GivenICreateATimeAndMaterial()
        {
            Home HomePage = new Home(driver);
            HomePage.ClickAdministration();
            HomePage.ClickTimenMaterial();


            Record turnupOptions = new Record(driver);
            turnupOptions.CreateNew();
            turnupOptions.CreateNewRecord("code", "description");
            turnupOptions.ValidateRecord();

        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            driver.Quit();
        }
    }
}
