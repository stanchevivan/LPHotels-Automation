using System;
using NUnit.Framework;
using PageObjects;
using TechTalk.SpecFlow;
using Tests.UI.Support;

namespace Tests.UI.FeaturesandSteps
{
    [Binding]
    public class DashboardSteps
    {
        readonly DashboardPage dashboardPage;
        readonly LPHBasePage lPHBasePage;

        public DashboardSteps(LPHBasePage lPHBasePage, DashboardPage dashboardPage)
        {
            this.dashboardPage = dashboardPage;
            this.lPHBasePage = lPHBasePage;
        }

        [When(@"shift window is open at ""(.*)"" ""(.*)""")]
        public void WhenDataForItemsIsSet(int x, int y)
        {
            dashboardPage.OpenShiftWindow(x, y);
            //dashboardPage.GetRoleSection("M").GetEmployee("employee-name-row-0").GetShift("9:00", "14:00");
        }

        [Given(@"LPH app is open on ""(.*)""")]
        public void LPHAppIsOpen(string environment)
        {
            ConfigurationReader.Initialize(environment);

            lPHBasePage.OpenLPH(ConfigurationReader.URL);
            dashboardPage.WaitToLoad();
        }

        [Then(@"shift popover is present")]
        public void ShiftPopoverIsPresent()
        {
            Assert.That(dashboardPage.IsShiftPopoverPresent, Is.True);
        }

        [When(@"Test step")]
        public void TestStep()
        {
            dashboardPage.GetRoleSection("C").GetEmployee("CC").GetShift("7:00", "16:00").Click();
            System.Threading.Thread.Sleep(10000);
        }
    }
}