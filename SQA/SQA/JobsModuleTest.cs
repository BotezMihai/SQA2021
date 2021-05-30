using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SQA.PageObjects;

namespace SQA
{
    [TestClass]
    public class JobsModuleTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private JobsPage jobsPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.hackerrank.com/");
            driver.FindElement(By.XPath("/html/body/div[3]/header/div/div/nav[2]/div/ul/li[1]/a")).Click();

            loginPage.goToLoginForm();
            homePage = loginPage.login("my correct email","my correct pass");           
            jobsPage = new JobsPage(driver);
        }
        [TestMethod]
        public void GIVEN_wrongPhoneNumberFormat_WHEN_fillFormForJob_THEN_displayInvalidLabel()
        {
            homePage.goToJobs();
            jobsPage.chooseRole();
            jobsPage.chooseLocation();
            jobsPage.chooseJob();
            jobsPage.apply();
            jobsPage.fillFormWithPhoneNumberWrong();
            jobsPage.clickAnywhereOnPage();
            Assert.AreEqual("Invalid", jobsPage.getTextInvalidPhoneNumber());
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}
