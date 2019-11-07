using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Common.Helpers
{
    public static class Do_Extension
    {
        public static Do Do(this IWebElement element, IWebDriver driver)
        {
            return new Do(element, driver);
        }
    }

    public class Do : BasePage
    {
        readonly IWebElement webElement;

        public Do(IWebElement element, IWebDriver webDriver) : base(webDriver)
        {
            webElement = element;
        }

        public void ClickOffSet(int x, int y)
        {
            new Actions(Driver).MoveToElement(webElement).MoveByOffset(x, y).Click().Perform();
        }
    }
}