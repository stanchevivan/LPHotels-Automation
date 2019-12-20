using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;

namespace PageObjects
{
    public class SessionSummary : LPHBasePage
    {
        private IWebElement webElement;

        public SessionSummary(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
        }

        private IWebElement piechart => webElement.FindElement(By.CssSelector(".donut-chart"));
        public Piechart PieChart => new Piechart(Driver, piechart);

        private IWebElement correct => webElement.FindElement(By.CssSelector(".legend-dot[style='background-color: rgb(68, 190, 186);'] + span"));
        private IWebElement under => webElement.FindElement(By.CssSelector(".legend-dot[style='background-color: rgb(125, 104, 165);'] + span"));
        private IWebElement above => webElement.FindElement(By.CssSelector(".legend-dot[style='background-color: rgb(245, 107, 93);'] + span"));

        public int Correct
        {
            get
            {
                try
                {
                    correct.Exist();
                }
                catch (NoSuchElementException)
                {
                    return 0;
                }

                return int.Parse(correct.Text);
            }
        }

        public int Under
        {
            get
            {
                try
                {
                    under.Exist();
                }
                catch (NoSuchElementException)
                {
                    return 0;
                }

                return int.Parse(under.Text);
            }
        }

        public int Above
        {
            get
            {
                try
                {
                    above.Exist();
                }
                catch (NoSuchElementException)
                {
                    return 0;
                }

                return int.Parse(above.Text);
            }
        }

    }
}