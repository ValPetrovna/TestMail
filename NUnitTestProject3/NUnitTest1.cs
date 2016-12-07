using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace NUnitTestProject3
{
    [TestFixture]
    public class NUnitTest1
    {
        private static IWebDriver driver;

        public static void init(TestContext arg)
        {
           
        }

        [Test]
        public void TestMethod1()
        {
            driver = new ChromeDriver();
            driver.Url = "https://google.com";
            driver.FindElement(By.Id("gb_70")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='link-signup']")).Text.Contains("Создать аккаунт"));
        }

        [Test]
        public void TestMethod2()
        {
            driver.FindElement(By.Id("Email")).SendKeys("valpetrovnatwo");
            driver.FindElement(By.Id("next")).Click();

            IWebElement myDynamicElement = (new WebDriverWait(driver, new TimeSpan(0, 0, 5)))
            .Until(ExpectedConditions.ElementIsVisible(By.Id("signIn")));
            Assert.IsTrue(driver.FindElement(By.Id("signIn")).GetAttribute("name").Contains("signIn"));
            // Console.WriteLine(driver.FindElement(By.Id("signIn")).GetAttribute("name"));
        }

        [Test]
        public void TestMethod3()
        {
            IWebElement password = (new WebDriverWait(driver, new TimeSpan(0, 0, 5)))
            .Until(ExpectedConditions.ElementIsVisible(By.Id("Passwd")));
            driver.FindElement(By.Id("Passwd")).SendKeys("vfhl.rtdbx32/");
            driver.FindElement(By.Id("signIn")).Click();
            // Thread.Sleep(1000);

            driver.Url = "https://mail.google.com";
            IWebElement signOutLink = (new WebDriverWait(driver, new TimeSpan(0, 0, 5)))
            .Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[starts-with(@href,'https://accounts.google.com/SignOutOptions')]")));

            Assert.IsTrue(driver.FindElement(By.XPath(".//*[starts-with(@href,'https://accounts.google.com/SignOutOptions')]")).GetAttribute("title").Contains("Аккаунт"));
        }

        [Test]
        public void TestMethod4()
        {
            driver.FindElement(By.XPath(".//*[starts-with(@href,'https://accounts.google.com/SignOutOptions')]")).Click();
            driver.FindElement(By.XPath(".//*[@id='gb_71']")).Click();

            IWebElement password = (new WebDriverWait(driver, new TimeSpan(0, 0, 5)))
            .Until(ExpectedConditions.ElementIsVisible(By.Id("Passwd")));

            Assert.IsTrue(driver.FindElement(By.Id("signIn")).GetAttribute("name").Contains("signIn"));

        }

         [Test]
         public void TestMethod5()
        {
            driver.Close();
        }

    }
}
