using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PageObjects
{
    public class Piechart : LPHBasePage
    {
        private IWebElement webElement;

        public Piechart(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
        }

        private IList<IWebElement> slices => webElement.FindElements(By.CssSelector("circle"));
        public IList<PieChartSlice> Slices => slices.Select(e => new PieChartSlice(Driver, e)).ToList();

        public PieChartSlice CorrectSlice => Slices.First(x => x.Type == "Correct");
        public PieChartSlice AboveSlice => Slices.First(x => x.Type == "Above");
        public PieChartSlice UnderSlice => Slices.First(x => x.Type == "Under");
    }
}