using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SQA.PageObjects
{
    class JobsPage
    {
        private IWebDriver driver;
        private IWebElement roleButton => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div[2]/div[4]/div/div/div/div/div[1]/div/div/div[1]/div[1]"));
        private IWebElement inputRole => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div[2]/div[4]/div/div/div/div/div[1]/div/div/div[1]/div[1]/div[2]/div/input"));
        private IWebElement inputLocation => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div[2]/div[4]/div/div/div[1]/div/div[2]/div/div/div[1]/div[1]/div[2]/div/input"));
        private IWebElement job => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div[3]/div/a[1]/div/div/div[2]"));

        private By applyBtnBox = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/section/div/div[1]/div/div[2]/aside/a/div");
        private IWebElement applyBtn => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[3]/section/div/div[1]/div/div[2]/aside/a/div"));

        private By phone = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div/form/fieldset[1]/div[3]/div/fieldset/div/div[2]/div[1]/div/input");

        private By body = By.XPath("/html/body");

        private By labelInvalid = By.XPath("/html/body/div[4]/div/div/div/div/div[3]/div/div/div/div/form/fieldset[1]/div[3]/div/fieldset/div/div[2]/div[2]");

        public JobsPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void chooseRole()
        {
            inputRole.SendKeys("backend");
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }

        public void chooseLocation()
        {
            inputLocation.SendKeys("ca");
            driver.SwitchTo().ActiveElement().SendKeys(Keys.Enter);
        }

        public void chooseJob()
        {
            job.Click();
        }

        public void apply()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(applyBtnBox));
            applyBtn.Click();
        }

        public void fillFormWithPhoneNumberWrong()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(phone));
            driver.FindElement(phone).SendKeys("wrongNumberFormat");
        }

        public void clickAnywhereOnPage()
        {
            driver.FindElement(body).Click();
        }

        public string getTextInvalidPhoneNumber()
        {
            IWebElement label = driver.FindElement(labelInvalid);
            return label.Text;
        }
    }
}
