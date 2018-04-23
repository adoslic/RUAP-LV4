using System;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {

        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTestCaseTest()
        {
            Random rgetrandomnd = new Random();
            int x = rgetrandomnd.Next(1, 101);

            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).SendKeys("ime");
            driver.FindElement(By.Id("input-lastname")).SendKeys("prezime");
            driver.FindElement(By.Id("input-email")).SendKeys(x+"nekimil@gmail.com");
            driver.FindElement(By.Id("input-telephone")).SendKeys("0987654321");
            driver.FindElement(By.Id("input-password")).SendKeys("password");
            driver.FindElement(By.Id("input-confirm")).SendKeys("password");
            driver.FindElement(By.XPath("//div[@id='content']/form/div/div")).Click();
            driver.FindElement(By.Name("agree")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | name=agree | ]]
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
