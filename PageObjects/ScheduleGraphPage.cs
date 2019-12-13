using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class ScheduleGraph : LPHBasePage
    {
        public ScheduleGraph(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        private IList<IWebElement> SessionSummaryList => Driver.FindElements(By.CssSelector(".swiper-slide-active .grid-single-session"));
    }
}
