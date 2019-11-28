using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class RoleSection : LPHBasePage
    {
        IWebElement webElement;
        public RoleSection(IWebDriver webDriver, IWebElement webElement) : base(webDriver)
        {
            this.webElement = webElement;
            PageFactory.InitElements(webDriver, this);
        }

        public string RoleName => webElement.GetAttribute("data-test-id");
        public IList<Employee> Employees;

        public Employee GetEmployee(string name)
        {
            return Employees.First(x => x.Id == name);
        }
    }
}