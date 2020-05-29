using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace NUnitTestProject
{
    internal class Record
    {
        private IWebDriver driver;

        public Record(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void CreateNew()
        {
            //Identify and Click on Create New button
            IWebElement createNew = driver.FindElement(By.ClassName("btn-primary"));
            createNew.Click();
        }

        internal void CreateNewRecord(string code, string description)
        {
            NewRecord(code, description);

        }
        internal void NewRecord(string code, string description)
        {
            //Identify and Enter Code
            driver.FindElement(By.Id("Code")).SendKeys("qwerty");

            //Identify and enter Description
            driver.FindElement(By.Name("Description")).SendKeys("qwerty");

            //Identify and enter Price
            IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
            price.SendKeys("2000");

            //Identify and click on Save button
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

        }

        internal void ValidateRecord()
        {
            Thread.Sleep(3000);

            try
            {
                while (true)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        var CodeColumn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]"));
                        Console.WriteLine(CodeColumn.Text);

                        if (CodeColumn.Text == "qwerty")
                        {
                            Console.WriteLine("Record Found");
                            return;
                        }

                    }
                    driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[3]/span")).Click();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Record not Found");
            }

        }

        internal void EditRecord()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();
            //Identify and Enter Code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.Clear();
            code.SendKeys("Testxyz");

            //Identify and enter Description
            IWebElement description = driver.FindElement(By.Name("Description"));
            description.Clear();
            description.SendKeys("Testxyz");
            {
                IWebElement price = driver.FindElement(By.CssSelector("input.k-formatted-value.k-input"));
                price.Click();
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string script = "return document.getElementById(\"Price\").value = 2020;";
                js.ExecuteScript(script);
            }
            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

        }

            internal void DeleteRecord()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            IAlert text = driver.SwitchTo().Alert();
            string alertmessage = text.Text;
            Console.WriteLine(alertmessage);
            {
                if (alertmessage.Equals("Are you sure you want to delete this record?"))

                {
                    Console.WriteLine("Correct message");
                }
                else
                {
                    Console.WriteLine("InCorrect message");
                }
            }
            text.Dismiss();
        }
    }
}