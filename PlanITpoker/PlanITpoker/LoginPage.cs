using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanITpoker
{
    public class LoginPage
    {
        IWebDriver driver;

        private By emailInput = By.XPath("/html/body/div[1]/div/section/form[1]/div[1]/div/input");
        private By passwordInput = By.XPath("/html/body/div[1]/div/section/form[1]/div[2]/div/input");
        private By loginBtn = By.ClassName("btn-login");
        private By errorMessage = By.XPath("/html/body/div[1]/div/section/form[1]/div[5]/div/div/div/span");

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By GetEmailInput()
        {
            return this.emailInput;
        }

        public By GetPasswordInput()
        {
            return this.passwordInput;
        }

        public By GetLoginBtn()
        {
            return this.loginBtn;
        }
        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }

        public CreateNewRoomPopup ClickLogin()
        {
            return new CreateNewRoomPopup(driver);
        }
        
    }
}
