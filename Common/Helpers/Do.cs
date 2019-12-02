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

        public void WaitToExist()
        {
            int w = 500;
            while (w >= 0)
            {
                try
                {
                    var t = webElement.TagName;
                    break;
                }
                catch (NoSuchElementException ex)
                {
                    if (w == 0)
                    {
                        throw ex;
                    }
                }
                System.Threading.Thread.Sleep(20);
                w--;
            }
        }

        public void ClickAndhold()
        {
            new Actions(Driver).ClickAndHold(webElement);
        }

        public void DragAndDropToOffset(int x, int y)
        {
            new Actions(Driver).DragAndDropToOffset(webElement, x, y);
        }
    }
}