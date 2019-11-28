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

        private IWebElement roleName => webElement.FindElement(By.CssSelector(".row-name-header-inner > span:first-of-type"));
        private IWebElement employeeSection;
        private IList<IWebElement> employees => employeeSection.FindElements(By.CssSelector(".employee-name-row"));

        public string Rolename => roleName.Text;
        public IList<Employee> Employees => employees.Select(e => new Employee(Driver, e)).ToList();

        public Employee GetEmployee(string initials)
        {
            return Employees.First(x => x.Initials == initials);
        }

        public void AssociateEmployees(IWebElement employeeSection)
        {
            this.employeeSection = employeeSection;
        }
    }
}