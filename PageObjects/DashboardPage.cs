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

        [FindsBy(How = How.CssSelector, Using = ".lphf_role-group")]
        private IWebElement ScheduleSection1 { get; set; }

        protected IWebElement Button => Driver.FindElement(By.CssSelector("[data-test-id='lphf_review-tna-btn']"));
        protected IWebElement ScheduleSection => Driver.FindElement(By.CssSelector(".lphf_role-group"));
        protected IList<IWebElement> ScheduleSections => Driver.FindElements(By.CssSelector(".lphf_role-group .lphf_grid"));
        protected IWebElement ShiftPopover => Driver.FindElement(By.CssSelector("form.lphf_shift-popover"));

        protected IList<IWebElement> employees => Driver.FindElements(By.CssSelector(".employee-name-row"));
        protected IList<Employee> Employees => employees.Select(e => new Employee(Driver, e)).ToList();

        protected IList<IWebElement> shiftItems => Driver.FindElements(By.CssSelector(".lphf_shift-item"));
        public IList<ShiftItem> ShiftItems => shiftItems.Select(e => new ShiftItem(Driver, e)).ToList();

        protected IList<IWebElement> roleSections => Driver.FindElements(By.CssSelector(".row-name-header"));
        protected IList<RoleSection> RoleSections => roleSections.Select(e => new RoleSection(Driver, e)).ToList();

        public bool IsShiftPopoverPresent => ShiftPopover.Exist();

        public RoleSection GetRoleSection(string roleName)
        {
            var roleSection = RoleSections.First(x => x.RoleName == roleName);
            roleSection.Employees = Employees.Where(x => x.Role == roleName).ToList();

            return roleSection;
        }

        public void OpenShiftWindow(int x, int y)
        {
            Driver.WaitElementToExists(ScheduleSection1);

            // Wait when element is not using FindsBy
            //int w = 500;
            //while (w >= 0)
            //{
            //    try
            //    {
            //        ScheduleSection.Exist();
            //        break;
            //    }
            //    catch (NoSuchElementException ex)
            //    {
            //        if (w == 0)
            //        {
            //            throw ex;
            //        }
            //    }
            //    System.Threading.Thread.Sleep(20);
            //    w--;
            //}

            ScheduleSections[3].Do(Driver).ClickOffSet(5, 5);
        }
    }
}
