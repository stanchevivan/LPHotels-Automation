using OpenQA.Selenium;

namespace PageObjects
{
    public class SidebarDailyTotal : LPHBasePage
    {
        private IWebElement webElement => Driver.FindElement(By.CssSelector(".lphf_side-drawer-wrapper--right"));

        public SidebarDailyTotal(IWebDriver webDriver) : base(webDriver)
        {
        }
        private IWebElement correct => Driver.FindElement(By.CssSelector(".lphf_right-drawer .legend-item:nth-of-type(1) .legend-number"));
        private IWebElement under => Driver.FindElement(By.CssSelector(".lphf_right-drawer .legend-item:nth-of-type(2) .legend-number"));
        private IWebElement above => Driver.FindElement(By.CssSelector(".lphf_right-drawer .legend-item:nth-of-type(3) .legend-number"));

        private IWebElement pieChart => webElement.FindElement(By.CssSelector(".donut-chart"));
        public Piechart PieChart => new Piechart(Driver, pieChart);

        public int Correct => int.Parse(correct.Text);
        public int Under => int.Parse(under.Text);
        public int Above => int.Parse(above.Text);
    }
}