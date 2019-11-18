using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class Calendar : LPHBasePage
    {
        public Calendar(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        protected IList<IWebElement> Days => Driver.FindElements(By.CssSelector(".MuiPickersDay-day:not(.MuiPickersDay-hidden"));

        public void SelectDay(int day)
        {
            Days[day - 1].Click();
        }
    }
}
