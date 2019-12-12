using System;
using System.Linq;
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
            shiftDetails.WaitToAppear();
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
            shiftDetails.WaitToDisappear();
        }

        [When(@"Shift details Save button is clicked")]
        public void ShiftDetailsSaveButtonIsClicked()
        {
            shiftDetails.UseSaveButton();
            shiftDetails.WaitToDisappear();
        }

        [When(@"Shift details Delete button is clicked")]
        public void ShiftDetailsDeleteButtonIsClicked()
        {
            shiftDetails.UseDeleteButton();
            shiftDetails.WaitToDisappear();
        }

        [Then(@"Shift for Role ""(.*)"" Employee ""(.*)"" Start time ""(.*)"" End time ""(.*)"" is ""(visible|not visible)""")]
        public void ShiftIsVisible(string role, string employee, string startTime, string endtime, string status)
        {
            Assert.That(dashboardPage.GetRoleSection(role).GetEmployee(employee)
                .ShiftItems.Any(x => x.StartTime == startTime && x.EndTime == endtime),
                status == "visible" ? Is.True : Is.Not.True,
                $"Shift with start time:{startTime} and end time:{endtime} should {(status == "visible" ? "exist" : "not exist")}, but it {(status == "visible" ? "does not" : "does")} !" );
        }

        [When(@"new shift window is open for Role ""(.*)"" Employee ""(.*)"" for ""(.*)""")]
        public void NewShiftWindowIsOpenForRoleEmployee(string role, string employee, string hour)
        {
            dashboardPage.GetRoleSection(role).GetEmployee(employee).OpenNewShiftWindow(hour);
            shiftDetails.WaitToAppear();
        }
    }
}