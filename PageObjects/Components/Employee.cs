using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class Employee : DashboardPage
    {
        IWebElement webElement;
        public Employee(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        public string Id => webElement.GetAttribute("data-test-id");
        public string Role => webElement.GetAttribute("data-test-id");

        public new IList<ShiftItem> ShiftItems => base.ShiftItems.Where(x => x.EmployeeId == Id).ToList();

        public ShiftItem GetShift(string startTime, string endTime)
        {
            return ShiftItems.First(x => x.StartTime == startTime && x.Endtime == endTime);
        }
    }
}