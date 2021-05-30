using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SQA.PageObjects
{
    class PracticePage
    {
        private IWebDriver driver;
        private By problem = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/section[1]/div[2]/div/a[5]/div/div[1]/div");
        private By submitButton = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/section/div/div/div/div[1]/section[2]/div[1]/div/div[2]/div/div[1]/div[2]/button[1]");
        private By inputSolution = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/section/div/div/div/div[1]/section[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[1]/div[2]/div/div/div[1]/div[2]");
        private By challenges = By.ClassName("challenges-list");
        public PracticePage(OpenQA.Selenium.IWebDriver browser)
        {
            driver = browser;
        }

        public void chooseProblemToBeSolved()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(challenges));
            IWebElement problemChoosed = driver.FindElement(problem);
            problemChoosed.Click();
        }

        public void insertSolution()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(submitButton));
            var wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("view-lines")));
            IWebElement text = driver.FindElement(inputSolution);
            IWebElement span = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/section/div/div/div/div[1]/section[2]/div[1]/div/div[2]/div/div[1]/div[1]/div[1]/div[2]/div/div/div[1]/div[2]/div[1]/div[4]/div[2]"));  
            span.Click();
            driver.SwitchTo().ActiveElement().SendKeys("test");
        
        }

        public void submitSolution()
        {
            driver.FindElement(submitButton).Click();
        }

        public string getMsg()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/section/div/div/div/div[1]/section[2]/div[2]/div/div/div/div/div[1]/p")));
            IWebElement msg= driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/section/div/div/div/div[1]/section[2]/div[2]/div/div/div/div/div[1]/p"));
            return msg.Text;
        }
    }
}
