using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SQA.PageObjects;

namespace SQA
{
   

    [TestClass]
    public class LoginModuleTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.hackerrank.com/");
            driver.FindElement(By.XPath("/html/body/div[3]/header/div/div/nav[2]/div/ul/li[1]/a")).Click();    
        }

        [TestMethod]
        public void GIVEN_correctCredentials_WHEN_login_THEN_shouldLoginSuccesfully()
        {
            loginPage.goToLoginForm();
            var homePage = loginPage.login("my correct email", "my correct pass");

            Assert.AreEqual("https://www.hackerrank.com/dashboard", homePage.getHomePageUrl());
        }

        [TestMethod]
        public void GIVEN_wrongCredentials_WHEN_login_THEN_shouldFailed()
        {
            loginPage.goToLoginForm();
            loginPage.login("wrongEmail", "wrongPass");
            Assert.AreEqual("Invalid login or password. Please try again.", loginPage.getLoginFailed());
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
