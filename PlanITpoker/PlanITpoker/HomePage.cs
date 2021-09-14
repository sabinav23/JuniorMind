using OpenQA.Selenium;
using System;

namespace PlanITpoker
{
    public class HomePage
    {
        IWebDriver driver;
        private By login = By.ClassName("btn-primary");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage ClickLogin()
        {
            driver.FindElement(login).Click();
            return new LoginPage(driver);
        }
    }
}
