using System;
using NUnit.Framework;
using PageObjects;
using TechTalk.SpecFlow;

namespace Tests.UI.FeaturesandSteps
{
    [Binding]
    public class DashboardSteps
    {
        readonly DashboardPage dashboardPage;

        public DashboardSteps(DashboardPage dashboardPage)
        {
            this.dashboardPage = dashboardPage;
        }

        [When(@"shift window is open at ""(.*)"" ""(.*)""")]
        public void WhenDataForItemsIsSet(int x, int y)
        {
            dashboardPage.OpenShiftWindow(x, y);
            System.Threading.Thread.Sleep(3000);
        }

        [Given(@"LPH app is open")]
        public void LPHAppIsOpen()
        {
            dashboardPage.OpenLPH();
        }

        [Then(@"shift popover is present")]
        public void ShiftPopoverIsPresent()
        {
            Assert.That(dashboardPage.IsShiftPopoverPresent, Is.True);
        }
    }
}