using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class Employee : LPHBasePage
    {
        IWebElement webElement, grid;

        public Employee(IWebDriver webDriver,IWebElement grid, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            this.grid = grid;
        }
        private IWebElement initials => webElement.FindElement(By.CssSelector(".employee-initials"));
        private IWebElement timeline => Driver.FindElement(By.CssSelector(".swiper-slide-active .lphf_timeline"));
        private IList<IWebElement> hours => timeline.FindElements(By.CssSelector(".single-item"));

        protected IList<IWebElement> shiftItems => Driver.FindElements(By.CssSelector(".lphf_shift-item"));
        public IList<ShiftItem> ShiftItems => shiftItems.Select(e => new ShiftItem(Driver, e)).Where(x => x.EmployeeId == Id).ToList();

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
            var shift = ShiftItems.FirstOrDefault(x => x.StartTime == startTime && x.EndTime == endTime);

            if (shift == null)
            {
                throw new Exception($"For employee {Initials}, no shift is found with start time: {startTime} and end time {endTime} !");
            }
            return shift;

        }

        public void OpenNewShiftWindow(string hour)
        {
            var hourElement = hours.First(x => x.Text == hour);

            int YOffSet = webElement.Location.Y - grid.Location.Y + (int)Math.Round((decimal)(webElement.Size.Height / 2));
            int XOffSet = hourElement.Location.X - grid.Location.X + 10;

            new Actions(Driver)
                .MoveToElement(grid, XOffSet, YOffSet)
                .Click()
                .Build().Perform();
        }
    }
}