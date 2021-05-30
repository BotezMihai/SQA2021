using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SQA.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        private IWebElement TxtEmail => driver.FindElement(By.Id("input-1"));
        private IWebElement TxtPassword => driver.FindElement(By.Id("input-2"));
        private IWebElement BtnSignIn => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div[2]/div[2]/div/div/div[2]/div/div/div[2]/div[1]/form/div[4]/button/div/span"));
        private IWebElement BtnLogin => driver.FindElement(By.Id("tab-7-item-1"));
        private IWebElement loginFailed => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div/div/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div/span"));

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        public void goToLoginForm (){
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/main/article/div/div/div[1]/div/div/div[2]/div[2]/div/div[4]/div/div/a/span")).Click();
        }

        public HomePage login(string user, string password)
        {
            TxtEmail.SendKeys(user);
            TxtPassword.SendKeys(password);
            BtnSignIn.Click();
            return new HomePage(driver);
        }

        public string getLoginFailed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div/div/div/div/div[2]/div/div/div[2]/div/div/div[2]/div[1]/div/span")));
            return loginFailed.Text;
        }
    }
}
