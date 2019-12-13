using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class SessionSummary : LPHBasePage
    {
        private IWebElement webElement;

        public SessionSummary(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        private IWebElement piechart => Driver.FindElement(By.CssSelector(".donut-chart"));
        public SessionPiechart PieChart => new SessionPiechart(Driver, piechart);

        private IList<IWebElement> dailyTotals => webElement.FindElements(By.CssSelector(".legend-items--wrapper"));

        public int Correct => int.Parse(dailyTotals.First(x => x.FindElement(By.CssSelector(".legend-dot")).GetAttribute("style") == "background-color: rgb(68, 190, 186);").FindElement(By.CssSelector("span:last-of-type")).Text);

        public int Under => int.Parse(dailyTotals.First(x => x.FindElement(By.CssSelector(".legend-dot")).GetAttribute("style") == "background-color: rgb(125, 104, 165);").FindElement(By.CssSelector("span:last-of-type")).Text);

        public int Above => int.Parse(dailyTotals.First(x => x.FindElement(By.CssSelector(".legend-dot")).GetAttribute("style") == "background-color: rgb(245, 107, 93);").FindElement(By.CssSelector("span:last-of-type")).Text);
    }
}
