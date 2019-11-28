﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class ShiftItem : LPHBasePage
    {
		private IWebElement webElement;

        public ShiftItem(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        protected IList<IWebElement> Days => Driver.FindElements(By.CssSelector(".MuiPickersDay-day:not(.MuiPickersDay-hidden"));

        public void SelectDay(int day)
        {
            Days[day - 1].Click();
        }
        protected IWebElement startTime => webElement.FindElement(By.CssSelector(".start-time"));
        protected IWebElement endTime => webElement.FindElement(By.CssSelector(".end-time"));

        protected IWebElement rightHandle => webElement.FindElement(By.CssSelector(".right-handle"));
        protected IWebElement leftHandle => webElement.FindElement(By.CssSelector(".left-handle"));

        public string StartTime => startTime.Text;
        public string Endtime => endTime.Text;

        public string Id => new Regex(@"(?<=shiftId:)\d+").Match(webElement.GetAttribute("data-test-id)")).Value;
        public string EmployeeId => new Regex(@"(?<=employeeId:)\d+").Match(webElement.GetAttribute("data-test-id)")).Value;

        public void DragLeft(int offset)
        {
            leftHandle.Click();
            new Actions(Driver).DragAndDropToOffset(leftHandle, offset, 0);
        }

        public void DragRight(int offset)
        {
            rightHandle.Click();
            new Actions(Driver).DragAndDropToOffset(rightHandle, offset, 0);
        }

        public void Click()
        {
            webElement.Click();
        }
    }
}
