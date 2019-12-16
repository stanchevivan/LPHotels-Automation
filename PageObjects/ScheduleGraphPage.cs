using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class ScheduleGraph : LPHBasePage
    {
        public ScheduleGraph(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        private IList<IWebElement> sessionSummaryList => Driver.FindElements(By.CssSelector(".swiper-slide-active .session-block"));

        public IList<SessionSummary> SessionSummaryList => sessionSummaryList.Select(e => new SessionSummary(Driver, e)).ToList();
    }
}