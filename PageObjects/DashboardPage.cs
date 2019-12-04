using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common.Helpers;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class DashboardPage : LPHBasePage
    {
        public DashboardPage(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".left-drawer")]
        private IWebElement ScheduleSection1 { get; set; }

        protected IWebElement Button => Driver.FindElement(By.CssSelector("[data-test-id='lphf_review-tna-btn']"));
        protected IWebElement ScheduleSection => Driver.FindElement(By.CssSelector(".lphf_role-group"));
        protected IList<IWebElement> ScheduleSections => Driver.FindElements(By.CssSelector(".lphf_role-group .lphf_grid"));
        protected IWebElement ShiftPopover => Driver.FindElement(By.CssSelector("form.lphf_shift-popover"));

        protected IList<IWebElement> employees => Driver.FindElements(By.CssSelector(".employee-name-row"));
        protected IList<Employee> Employees => employees.Select(e => new Employee(Driver, e)).ToList();

        protected IList<IWebElement> employeSections => Driver.FindElements(By.CssSelector(".row-name-header + div"));

        protected IList<IWebElement> roleSections => Driver.FindElements(By.CssSelector(".row-name-header"));
        protected IList<RoleSection> RoleSections => roleSections.Select(e => new RoleSection(Driver, e)).ToList();

        public bool IsShiftPopoverPresent => ShiftPopover.Exist();

        public RoleSection GetRoleSection(string roleName)
        {
            int indexOfRole = -1;
            for (int i = 0; i < RoleSections.Count; i++)
            {
                if (RoleSections[i].Rolename == roleName)
                {
                    indexOfRole = i;
                    break;
                }
            }

            var roleSection = RoleSections[indexOfRole];

            roleSection.AssociateEmployeeSection(employeSections[indexOfRole]);

            return roleSection;
        }

        public void OpenShiftWindow(int x, int y)
        {
            
            ScheduleSections[16].Do(Driver).ClickOffSet(5, 5);
        }

        public void WaitToLoad()
        {
            Driver.WaitElementToExists(ScheduleSection1);
        }
    }
}
