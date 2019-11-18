using System.Collections.Generic;
using System.Text.RegularExpressions;
using Common.Helpers;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;
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
        protected IList<IWebElement> ShiftBlocks => Driver.FindElements(By.CssSelector(".lphf_shift-item"));

        public bool IsShiftPopoverPresent => ShiftPopover.Exist();
        public bool AreShiftBlocksPresent => ShiftBlocks.Count > 0;

        public void OpenShiftWindow(int x, int y)
        {
            Driver.WaitElementToExists(ScheduleSection1);
            ScheduleSections[3].Do(Driver).ClickOffSet(x, y);
        }

        public string StartCoord => ShiftBlocks[0].GetAttribute("style").Split(';')[2];
        string r => new Regex(@"\d{2}").Match(StartCoord).Value;

        
    }
}