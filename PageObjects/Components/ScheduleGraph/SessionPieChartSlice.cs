using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class PieChartSlice : LPHBasePage
    {
        private IWebElement webElement;

        public PieChartSlice(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        public string Colour => webElement.GetAttribute("stroke");
        public string PercentageText => webElement.GetAttribute("stroke-dasharray").Split(' ')[0];
        public int PercentageNumber => (int)Math.Round(decimal.Parse(PercentageText));
    }
}