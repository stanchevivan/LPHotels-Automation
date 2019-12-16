using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        }
        private IWebElement employeeSection;
        private IWebElement grid;

        private IWebElement roleName => webElement.FindElement(By.CssSelector(".row-name-header-inner > span:first-of-type"));
        private IList<IWebElement> employees => employeeSection.FindElements(By.CssSelector(".employee-name-row"));

        public string Id
        {
            get
            {
                var testAttribute = webElement.GetAttribute("data-test-id");
                return Regex.Match(testAttribute, @"(?<=role-name-)\d+").Value;
            }
        }

        public string Rolename => roleName.Text;

        public IList<Employee> Employees => employees.Select(e => new Employee(Driver, grid, e)).ToList();

        public Employee GetEmployee(string initials)
        {
            var employee = Employees.FirstOrDefault(x => x.Initials == initials);

            if (employee == null)
            {
                throw new System.Exception($"Employee with initials {initials} not found !");
            }

            return employee;
        }

        public void AssociateEmployeeSection(IWebElement employeeSection)
        {
            this.employeeSection = employeeSection;
        }

        public void AssociateGrid(IWebElement grid)
        {
            this.grid = grid;
        }
    }
}