using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace PlanITpoker.Specs
{
    [Binding]
    public class PlanITpokerSteps
    {
        private IWebDriver driver;
        private HomePage home;
        private LoginPage login;
        private string _errorMessage;

        public PlanITpokerSteps()
        {
            this.driver = new ChromeDriver();
            this.home = new HomePage(driver);
            driver.Navigate().GoToUrl("https://www.planitpoker.com/");
            this.login = home.ClickLogin();
        }

        [Given(@"the first input is ""(.*)""")]
        public void GivenTheFirstInputIs(string username)
        {
            login.Username = username;
        }
        
        [Given(@"the second input is ""(.*)""")]
        public void GivenTheSecondInputIs(string password)
        {
            login.Password = password;
        }
        
        [When(@"clicking the login button")]
        public void WhenTheClickingTheLoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(login.GetEmailInput()).SendKeys(login.Username);
            driver.FindElement(login.GetPasswordInput()).SendKeys(login.Password);
            wait.Until(e => e.FindElement(login.GetLoginBtn())).Click();
            _errorMessage = login.GetErrorMessage();
        }
        
        [Then(@"the title of the current page should be ""(.*)""")]
        public void ThenTheTitleOfTheCurrentPageShouldBe(string title)
        {
            driver.Title.Equals(title);
            
        }

        [Then(@"the error message for wrong password should appear (.*)")]
        public void ThenTheErrorMessageShouldAppear(string errorMessage)
        {
            _errorMessage.Equals(errorMessage);
        }

    }
}
