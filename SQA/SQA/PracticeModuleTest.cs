using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SQA.PageObjects;

namespace SQA
{
    [TestClass]
    public class PracticeModuleTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private PracticePage practicePage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.hackerrank.com/");
            driver.FindElement(By.XPath("/html/body/div[3]/header/div/div/nav[2]/div/ul/li[1]/a")).Click();

            loginPage.goToLoginForm();
            homePage = loginPage.login("my correct email", "my correct pass");
            practicePage = new PracticePage(driver);
        }

        [TestMethod]
        public void GIVEN_wrongSolutionStructure_WHEN_submitSolution_THEN_runtimeError()
        {
            homePage.chooseTopic();
            practicePage.chooseProblemToBeSolved();
            practicePage.insertSolution();
            practicePage.submitSolution();
            string msg = practicePage.getMsg();
            Assert.AreEqual("Runtime Error :(", msg);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}