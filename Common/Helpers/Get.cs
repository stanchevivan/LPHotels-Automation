using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Common.Helpers
{
    public static class Get_Extension
    {
        public static Get Get(this IWebElement element)
        {
            return new Get(element);
        }
    }

    public class Get
    {
        readonly IWebElement webElement;

        public Get(IWebElement element)
        {
            webElement = element;
        }

        public List<string> Classes => webElement.GetAttribute("class").Split(' ').ToList();
        public string Text => webElement.Text;
        public bool ElementDisplayed => webElement.Displayed;
        public bool ElementEnabled => webElement.Enabled;

        public bool ElementPresent
        {
            get
            {
                try
                {
                    var t = webElement.TagName;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

                return true;
            }
        }

        public bool HasClass(string className)
        {
            return Classes.Contains(className);
        }

        public bool HasAttribute(string attributeName)
        {
            return !string.IsNullOrEmpty(webElement.GetAttribute(attributeName));
        }
    }
}