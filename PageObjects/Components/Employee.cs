using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class Employee : LPHBasePage
    {
        IWebElement webElement;
        public Employee(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }
        private IWebElement initials => webElement.FindElement(By.CssSelector(".employee-initials"));

        protected IList<IWebElement> shiftItems => Driver.FindElements(By.CssSelector(".lphf_shift-item"));
        public IList<ShiftItem> ShiftItems => shiftItems.Select(e => new ShiftItem(Driver, e)).Where(x => x.EmployeeId == Id).ToList();
        //public new IList<ShiftItem> ShiftItems => base.ShiftItems.Where(x => x.EmployeeId == Id).ToList();

        public string Initials => initials.Text;

        public string Id
        {
            get
            {
                var testAttribute = webElement.GetAttribute("data-test-id");
                return Regex.Match(testAttribute, @"(?<=employeeId:)\d+").Value;
            }
        }
        public string RoleId
        {
            get
            {
                var testAttribute = webElement.GetAttribute("data-test-id");
                return Regex.Match(testAttribute, @"(?<=roleId:)\d+").Value;
            }
        }


        public ShiftItem GetShift(string startTime, string endTime)
        {
            return ShiftItems.First(x => x.StartTime == startTime && x.Endtime == endTime);
        }
    }
}