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
    public class ScheduleGrid : LPHBasePage
    {
        public ScheduleGrid(IWebDriver webDriver) : base(webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".left-drawer")]
        private IWebElement ScheduleSection1 { get; set; }
        
        protected IList<IWebElement> activeGridsList => Driver.FindElements(By.CssSelector(".swiper-slide-active .lphf_role-group .lphf_grid"));
        
        protected IWebElement ShiftPopover => Driver.FindElement(By.CssSelector("form.lphf_shift-popover"));

        protected IList<IWebElement> employeSections => Driver.FindElements(By.CssSelector(".row-name-header + div"));

        protected IList<IWebElement> roleSections => Driver.FindElements(By.CssSelector(".row-name-header"));
        protected List<RoleSection> RoleSections => roleSections.Select(e => new RoleSection(Driver, e)).ToList();

        public bool IsShiftPopoverPresent => ShiftPopover.Exist();

        public RoleSection GetRoleSection(string roleName)
        {
            int indexOfRole = RoleSections.FindIndex(x => x.Rolename == roleName);

            if (indexOfRole == -1)
            {
                throw new System.Exception($"Role with name {roleName} not found !");
            }
            var roleSection = RoleSections[indexOfRole];

            roleSection.AssociateEmployeeSection(employeSections[indexOfRole]);
            roleSection.AssociateGrid(activeGridsList[indexOfRole]);

            return roleSection;
        }

        public void OpenShiftWindow(int x, int y)
        {
            
            activeGridsList[16].Do(Driver).ClickOffSet(5, 5);
        }

        public void WaitToLoad()
        {
            Driver.WaitElementToExists(ScheduleSection1);
        }
    }
}
