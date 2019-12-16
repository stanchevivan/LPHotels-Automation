using System.Collections.Generic;
using OpenQA.Selenium;

namespace PageObjects
{
    public class CalendarPage : LPHBasePage
    {
        public CalendarPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        protected IList<IWebElement> days => Driver.FindElements(By.CssSelector(".MuiPickersDay-day:not(.MuiPickersDay-hidden"));
        
        public void SelectDay(int day)
        {
            days[day - 1].Click();
        }
    }
}
