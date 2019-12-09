using System;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
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
        readonly ShiftDetails shiftDetails;

        public DashboardSteps(LPHBasePage lPHBasePage, DashboardPage dashboardPage, ShiftDetails shiftDetails)
        {
            this.dashboardPage = dashboardPage;
            this.lPHBasePage = lPHBasePage;
            this.shiftDetails = shiftDetails;
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

            lPHBasePage.OpenLPH(ConfigurationReader.URL);
            dashboardPage.WaitToLoad();
        }

        [Then(@"shift popover is present")]
        public void ShiftPopoverIsPresent()
        {
            Assert.That(dashboardPage.IsShiftPopoverPresent, Is.True);
        }

        [When(@"Shift details are opened for Role ""(.*)"" Employee ""(.*)"" Start time ""(.*)"" End time ""(.*)""")]
        public void ShiftDetailsAreOpened(string role, string employee, string startTime, string endtime)
        {
            dashboardPage.GetRoleSection(role).GetEmployee(employee).GetShift(startTime, endtime).OpenDetails();
        }

        [When(@"Shift details Start time is set to ""(.*)"" and End Time is set to ""(.*)""")]
        public void ShiftDetailsTimesAreSet(string startTime, string endTime)
        {
            if (!string.IsNullOrEmpty(startTime))
            {
                shiftDetails.StartTime = startTime;
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                shiftDetails.EndTime = endTime;
            }
        }

        [When(@"Shift details Cancel button is clicked")]
        public void ShiftDetailsCancelButtonIsClicked()
        {
            shiftDetails.UseCancelButton();
        }

        [When(@"Shift details Save button is clicked")]
        public void ShiftDetailsSaveButtonIsClicked()
        {
            shiftDetails.UseSaveButton();
        }

        [When(@"Shift details Delete button is clicked")]
        public void ShiftDetailsDeleteButtonIsClicked()
        {
            shiftDetails.UseDeleteButton();
        }

        [When(@"test step")]
        public void TestStep()
        {
            dashboardPage.GetRoleSection("C").GetEmployee("PP").OpenNewShiftWindow("10:00");
            System.Threading.Thread.Sleep(3000);
        }
    }
}