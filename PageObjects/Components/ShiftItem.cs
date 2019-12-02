using System.Collections.Generic;
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

        protected IWebElement rightHandle => webElement.FindElement(By.CssSelector(".right-handle > .handle-dot"));
        protected IWebElement leftHandle => webElement.FindElement(By.CssSelector(".left-handle > .handle-dot"));

        protected IWebElement roleSymbol => webElement.FindElement(By.CssSelector(".role-symbol"));

        public string StartTime => startTime.Text;
        public string Endtime => endTime.Text;

        public string Id => new Regex(@"(?<=shiftId:)\d+").Match(webElement.GetAttribute("data-test-id)")).Value;
        public string EmployeeId => new Regex(@"(?<=employeeId:)\d+").Match(webElement.GetAttribute("data-test-id)")).Value;

        public string Symbol => roleSymbol.Text;

        public void ExpandLeft(int offset)
        {
            webElement.Click();
            webElement.Click();
            new Actions(Driver).DragAndDropToOffset(leftHandle, offset, 0).Build().Perform();
        }

        public void ExpandRight(int offset)
        {
            webElement.Click();
            webElement.Click();
            new Actions(Driver).DragAndDropToOffset(rightHandle, offset, 0).Build().Perform();
        }

        public void Click()
        {
            webElement.Click();
        }
    }
}
