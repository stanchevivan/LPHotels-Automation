using System.Collections.Generic;
using System.Text.RegularExpressions;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class ShiftDetails : LPHBasePage
    {

        public ShiftDetails(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        private IWebElement startTime => Driver.FindElement(By.CssSelector(".lphf_shift-popover__section [type='time']:first-of-type"));
        private IWebElement endTime => Driver.FindElement(By.CssSelector(".lphf_shift-popover__section [type='time']:last-of-type"));

        private IWebElement cancelButton => Driver.FindElement(By.CssSelector(".btn-"));
        private IWebElement saveButton => Driver.FindElement(By.CssSelector(".save-button"));
        private IWebElement deleteButton => Driver.FindElement(By.CssSelector(".btn-red-border-font"));


        public string StartTime
        {
            get
            {
                return startTime.GetAttribute("value");
            }

            set
            {
                startTime.ClearAndSendKeys(value);
            }
        }

        public string EndTime
        {
            get
            {
                return endTime.GetAttribute("value");
            }

            set
            {
                endTime.ClearAndSendKeys(value);
            }
        }

        public void UseCancelButton()
        {
            new Actions(Driver).MoveToElement(cancelButton).Click();
        }

        public void UseSaveButton()
        {
            new Actions(Driver).MoveToElement(saveButton).Click();
        }

        public void UseDeleteButton()
        {
            new Actions(Driver).MoveToElement(deleteButton).Click();
        }
    }
}
