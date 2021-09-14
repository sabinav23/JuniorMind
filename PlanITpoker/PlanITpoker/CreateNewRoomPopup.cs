using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanITpoker
{
    public class CreateNewRoomPopup
    {
        IWebDriver driver;

        private By popupElement = By.XPath("/html/body/div[1]/div/div[1]/div/div/section/div[1]/div/div/div");

        public CreateNewRoomPopup(IWebDriver driver)
        {
            this.driver = driver;
        }
        public By GetPopupElement()
        {
            return popupElement;
        }
    }
}
