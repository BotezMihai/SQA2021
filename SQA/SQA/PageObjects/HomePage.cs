using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SQA.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private By dashboard = By.ClassName("page-label");
        private By pythonTopic = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div[3]/div[2]/div/ul/li[7]/a/div");
        private By jobs = By.XPath("/html/body/div[4]/div/div/div/div/div[1]/nav/div/div[1]/ul/li[5]/a");

        public HomePage(OpenQA.Selenium.IWebDriver browser)
        {
            driver = browser;
        }

        public string getHomePageUrl()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(dashboard));
            return driver.Url;
        }

        public void chooseTopic()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(pythonTopic));
            driver.FindElement(pythonTopic).Click();
        }

        public void goToJobs()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(jobs));
            driver.FindElement(jobs).Click();
        }
    }
}
