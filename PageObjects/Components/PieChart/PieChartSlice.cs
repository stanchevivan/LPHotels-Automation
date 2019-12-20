using System;
using OpenQA.Selenium;

namespace PageObjects
{
    public class PieChartSlice : LPHBasePage
    {
        private readonly IWebElement webElement;

        public PieChartSlice(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
        }
        public string Type => Colour switch
        {
            "#44beba" => "Correct",
            "#7d68a5" => "Under",
            "#f56b5d" => "Above",
            _ => throw new Exception("Could not parse session slice colour!")
        };

        public string Colour => webElement.GetAttribute("stroke");
        public string PercentageText => webElement.GetAttribute("stroke-dasharray").Split(' ')[0];
        public int PercentageNumber => (int)Math.Round(decimal.Parse(PercentageText));
    }
}