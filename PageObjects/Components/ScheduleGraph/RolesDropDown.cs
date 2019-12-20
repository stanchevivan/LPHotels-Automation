using System.Collections.Generic;
using System.Linq;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;

namespace PageObjects
{
    public class RolesDropDown : LPHBasePage
    {
        private IWebElement webElement;

        public RolesDropDown(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
        }

        IList<IWebElement> Options => webElement.FindElements(By.CssSelector(".MuiMenu-list > li > div > span"));

        public void SelectRole(string role)
        {
            Options.First(x => x.Text == role).Click();
        }

        public void WaitToDisappear()
        {
            Driver.WaitElementToDisappear(webElement);
        }
    }
}