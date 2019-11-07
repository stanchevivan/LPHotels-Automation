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

        public DashboardSteps(DashboardPage dashboardPage)
        {
            this.dashboardPage = dashboardPage;
        }

        [When(@"shift window is open at ""(.*)"" ""(.*)""")]
        public void WhenDataForItemsIsSet(int x, int y)
        {
            dashboardPage.OpenShiftWindow(x, y);
        }

        [Given(@"LPH app is open on ""(.*)""")]
        public void LPHAppIsOpen(string environment)
        {
            ConfigurationReader.Initialize(environment);

            dashboardPage.OpenLPH(ConfigurationReader.URL);
        }

        [Then(@"shift popover is present")]
        public void ShiftPopoverIsPresent()
        {
            Assert.That(dashboardPage.IsShiftPopoverPresent, Is.True);
        }
    }
}