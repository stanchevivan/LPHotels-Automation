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

        private IList<IWebElement> Options => ListBox.FindElements(By.CssSelector(".MuiMenu-list > li > div > span"));
        private IWebElement ListBox => Driver.FindElement(By.CssSelector(".MuiMenu-list"));

        public void SelectRole(string role)
        {
            Options.First(x => x.Text == role).Click();
        }

        public void WaitToDisappear()
        {
            Driver.WaitElementToDisappear(ListBox);
        }

        public void Click()
        {
            webElement.Click();
        }

        public void WaitToAppear()
        {
            Driver.WaitElementToExists(ListBox);
        }
    }
}