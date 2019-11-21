using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class CalendarPage : LPHBasePage
    {
        public CalendarPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        protected IList<IWebElement> days => Driver.FindElements(By.CssSelector(".MuiPickersDay-day:not(.MuiPickersDay-hidden"));
        
        public void SelectDay(int day)
        {
            days[day - 1].Click();
        }
    }
}
