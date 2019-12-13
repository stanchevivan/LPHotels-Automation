using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class SessionPiechart : LPHBasePage
    {
        private IWebElement webElement;

        public SessionPiechart(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        private IList<IWebElement> slices => webElement.FindElements(By.CssSelector("circle"));
        public IList<PieChartSlice> Slices => slices.Select(e => new PieChartSlice(Driver, e)).ToList();
    }
}