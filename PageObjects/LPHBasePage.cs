using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;

namespace PageObjects
{
    public class LPHBasePage : BasePage
    {
        public LPHBasePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void OpenLPH(string environemnt)
        {
            Driver.Navigate().GoToUrl(environemnt);
        }
    }
}
