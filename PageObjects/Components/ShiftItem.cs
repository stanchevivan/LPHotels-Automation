using System.Collections.Generic;
using OpenQA.Selenium;
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

        public string StartTime => startTime.Text;
        public string Endtime => endTime.Text;

        public string EmployeeId => webElement.GetAttribute("data-test-id)");
        public string Role => webElement.GetAttribute("data-test-id)");
    }
}
