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

        [FindsBy(How = How.CssSelector, Using = ".save-button")]
        private IWebElement saveButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-")]
        private IWebElement cancelButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-red-border-font")]
        private IWebElement deleteButton { get; set; }

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
            new Actions(Driver).MoveToElement(cancelButton).Click().Build().Perform();
        }

        public void UseSaveButton()
        {
            new Actions(Driver).MoveToElement(saveButton).Click().Build().Perform();
        }

        public void UseDeleteButton()
        {
            new Actions(Driver).MoveToElement(deleteButton).Click().Build().Perform();
        }

        public void WaitToAppear()
        {
            Driver.WaitIsClickable(deleteButton);
            // TODO: Replace sleep with wait for refresh of shifts
            System.Threading.Thread.Sleep(100);
        }

        public void WaitToDisappear()
        {
            Driver.WaitElementToDisappear(deleteButton);
            // TODO: Replace sleep with wait
            System.Threading.Thread.Sleep(100);
        }
    }
}
