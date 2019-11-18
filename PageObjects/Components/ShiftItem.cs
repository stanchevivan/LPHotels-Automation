using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class ShiftItem : LPHBasePage
    {
        public ShiftItem(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        protected IList<IWebElement> Days => Driver.FindElements(By.CssSelector(".MuiPickersDay-day:not(.MuiPickersDay-hidden"));
    }
}