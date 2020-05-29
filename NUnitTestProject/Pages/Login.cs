using System;
using OpenQA.Selenium;

namespace NUnitTestProject
{
    internal class Login
    {
        private IWebDriver driver;

        IWebElement UserName => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Name("Password"));
        IWebElement Loginbutton => driver.FindElement(By.ClassName("btn-default"));

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void LoginSuccess()
        {
            //Navigate to Turn up application
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            WaitHelpers.ForElement(By.Id("UserName"), driver, TimeSpan.FromSeconds(10));

            // Identify and enter username
            UserName.SendKeys("hari");

            //Identify and enter password
            Password.SendKeys("123123");

            //Identify and click on Login button
            Loginbutton.Click();

        }
        public void LoginFailure()
        {
            //Identify username
            // enter hari as username
            UserName.SendKeys("hari");

            //identfying password & sending password
            Password.SendKeys("123123");
        }
    }
}