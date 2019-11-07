using System;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjects
{
    public class LPHBasePage : BasePage
    {
        public LPHBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void OpenLPH()
        {
            Driver.Navigate().GoToUrl("localhost:3000");
        }
    }
}
