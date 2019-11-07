using System;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace PageObjects
{
    public class DashboardPage : LPHBasePage
    {
        public DashboardPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        protected IWebElement Button => Driver.FindElement(By.CssSelector("[data-test-id='lphf_review-tna-btn']"));
        protected IWebElement ScheduleSection => Driver.FindElement(By.CssSelector(".lphf_role-group"));
        protected IList<IWebElement> ScheduleSections => Driver.FindElements(By.CssSelector(".lphf_role-group .lphf_grid"));
        protected IWebElement ShiftPopover => Driver.FindElement(By.CssSelector("form.lphf_shift-popover"));

        public bool IsShiftPopoverPresent => ShiftPopover.Exist();

        public void OpenShiftWindow(int x, int y)
        {
            //System.Threading.Thread.Sleep(5000);
            //new WebDriverWait(Driver, TimeSpan.FromSeconds(30)).Until(driver => Button.Exist());
            //Driver.WaitElementToExists(ScheduleSection);
            int w = 500;
            while (w >= 0)
            {
                try
                {
                    ScheduleSection.Exist();
                    break;
                }
                catch (NoSuchElementException ex)
                {
                    if (w == 0)
                    {
                        throw ex;
                    }
                }
                System.Threading.Thread.Sleep(20);
                w--;
            }

            new Actions(Driver).MoveToElement(ScheduleSections[3]).MoveByOffset(x, y).Click().Perform();
        }
    }
}
