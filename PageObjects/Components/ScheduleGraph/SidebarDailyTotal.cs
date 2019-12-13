using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class SidebarDailyTotal : LPHBasePage
    {
        private IWebElement webElement;

        public SidebarDailyTotal(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }
        private IWebElement correct => Driver.FindElement(By.CssSelector(".lphf_right-drawer.legend-item:nth-of-type(1) .legend-number"));
        private IWebElement under => Driver.FindElement(By.CssSelector(".lphf_right-drawer.legend-item:nth-of-type(2) .legend-number"));
        private IWebElement above => Driver.FindElement(By.CssSelector(".lphf_right-drawer.legend-item:nth-of-type(3) .legend-number"));

        public int Correct => int.Parse(correct.Text);
        public int Under => int.Parse(under.Text);
        public int Above => int.Parse(above.Text);
    }
}