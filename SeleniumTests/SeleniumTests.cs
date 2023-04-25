using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SQTAssignmentTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
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
        public void TheSQTAssignmentTest()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("18");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("rural");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 5", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void TheSQTAssignmentTest2()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("35");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("rural");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 2.5", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void TheSQTAssignmentTest3()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("16");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("rural");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 0", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void TheSQTAssignmentTest4()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("32");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("urban");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 6", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void TheSQTAssignmentTest5()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("51");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("urban");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 2.5", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        [Test]
        public void TheSQTAssignmentTest6()
        {
            driver.Navigate().GoToUrl("https://localhost:7249/");
            driver.FindElement(By.Id("ageInput")).Click();
            driver.FindElement(By.Id("ageInput")).Clear();
            driver.FindElement(By.Id("ageInput")).SendKeys("16");
            driver.FindElement(By.Id("locationInput")).Click();
            driver.FindElement(By.Id("locationInput")).Clear();
            driver.FindElement(By.Id("locationInput")).SendKeys("urban");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            try
            {
                Assert.AreEqual("Premium: 0", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Calculate Premium'])[1]/following::h4[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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

