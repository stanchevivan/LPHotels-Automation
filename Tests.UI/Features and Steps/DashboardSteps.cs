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
        readonly ScheduleGrid scheduleGridPage;
        readonly ScheduleGraph scheduleGraphPage;
        readonly SidebarDailyTotal sidebarDailyTotal;
        readonly LPHBasePage lPHBasePage;
        readonly ShiftDetails shiftDetails;

        public DashboardSteps(LPHBasePage lPHBasePage, ScheduleGrid scheduleGridPage, ScheduleGraph scheduleGraphPage, ShiftDetails shiftDetails, SidebarDailyTotal sidebarDailyTotal)
        {
            this.scheduleGridPage = scheduleGridPage;
            this.scheduleGraphPage = scheduleGraphPage;
            this.sidebarDailyTotal = sidebarDailyTotal;
            this.lPHBasePage = lPHBasePage;
            this.shiftDetails = shiftDetails;
        }

        [When(@"shift window is open at ""(.*)"" ""(.*)""")]
        public void WhenDataForItemsIsSet(int x, int y)
        {
            scheduleGridPage.OpenShiftWindow(x, y);
        }

        [Given(@"LPH app is open on ""(.*)""")]
        public void LPHAppIsOpen(string environment)
        {
            ConfigurationReader.Initialize(environment);

            lPHBasePage.OpenLPH(ConfigurationReader.URL);
            scheduleGridPage.WaitToLoad();
        }

        [Then(@"shift popover is present")]
        public void ShiftPopoverIsPresent()
        {
            Assert.That(scheduleGridPage.IsShiftPopoverPresent, Is.True);
        }

        [When(@"Shift details are opened for Role ""(.*)"" Employee ""(.*)"" Start time ""(.*)"" End time ""(.*)""")]
        public void ShiftDetailsAreOpened(string role, string employee, string startTime, string endtime)
        {
            scheduleGridPage.GetRoleSection(role).GetEmployee(employee).GetShift(startTime, endtime).OpenDetails();
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
            Assert.That(scheduleGridPage.GetRoleSection(role).GetEmployee(employee)
                .ShiftItems.Any(x => x.StartTime == startTime && x.EndTime == endtime),
                status == "visible" ? Is.True : Is.Not.True,
                $"Shift with start time:{startTime} and end time:{endtime} should {(status == "visible" ? "exist" : "not exist")}, but it {(status == "visible" ? "does not" : "does")} !");
        }

        [When(@"new shift window is open for Role ""(.*)"" Employee ""(.*)"" for ""(.*)""")]
        public void NewShiftWindowIsOpenForRoleEmployee(string role, string employee, string hour)
        {
            scheduleGridPage.GetRoleSection(role).GetEmployee(employee).OpenNewShiftWindow(hour);
            shiftDetails.WaitToAppear();
        }

        [Then(@"Verify Daily totals equal session totals")]
        public void VerifyDailyTotalsEqualSessionTotals()
        {
            Assert.Multiple
                (() =>
                    {
                        Assert.That(scheduleGraphPage.SessionSummaryList.Sum(x => x.Correct), Is.EqualTo(sidebarDailyTotal.Correct), "Daily Correct is not equal to the sum of sessions correct !");
                        Assert.That(scheduleGraphPage.SessionSummaryList.Sum(x => x.Above),
                            Is.EqualTo(sidebarDailyTotal.Above), "Daily Above is not equal to the sum of sessions correct !");
                        Assert.That(scheduleGraphPage.SessionSummaryList.Sum(x => x.Under),
                            Is.EqualTo(sidebarDailyTotal.Under), "Daily Under is not equal to the sum of sessions correct !");
                    }
                 );
        }

        [Then(@"Verify Daily Total pie chart percentages are correct")]
        public void ThenVerifyDailyTotalPieChartPercentagesAreCorrect()
        {
            if (sidebarDailyTotal.Correct != 0)
            {
                int correctPercentage = (int)Math.Round(
                    100 * ((decimal)sidebarDailyTotal.Correct / (sidebarDailyTotal.Correct + sidebarDailyTotal.Above + sidebarDailyTotal.Under))
                    );
                Assert.That(correctPercentage, Is.EqualTo(sidebarDailyTotal.PieChart.CorrectSlice.PercentageNumber), "Daily Total Pie chart 'Correct' slice has incorrect size");
            }

            if (sidebarDailyTotal.Under != 0)
            {
                int underPercentage = (int)Math.Round(
                    100 * ((decimal)sidebarDailyTotal.Under / (sidebarDailyTotal.Correct + sidebarDailyTotal.Above + sidebarDailyTotal.Under))
                    );
                Assert.That(underPercentage, Is.EqualTo(sidebarDailyTotal.PieChart.UnderSlice.PercentageNumber), "Daily Total Pie chart 'Under' slice has incorrect size");
            }

            if (sidebarDailyTotal.Above != 0)
            {
                int abovePercentage = (int)Math.Round(
                    100 * ((decimal)sidebarDailyTotal.Above / (sidebarDailyTotal.Correct + sidebarDailyTotal.Above + sidebarDailyTotal.Under))
                    );
                Assert.That(abovePercentage, Is.EqualTo(sidebarDailyTotal.PieChart.AboveSlice.PercentageNumber), "Daily Total Pie chart 'Above' slice has incorrect size");
            }
        }

        [Then(@"Verify Session pie chart percentages are correct")]
        public void ThenVerifySessionPieChartPercentagesAreCorrect()
        {
            foreach (var session in scheduleGraphPage.SessionSummaryList)
            {
                if (session.Correct != 0)
                {
                    int correctPercentage = (int)Math.Round(
                        100 * ((decimal)session.Correct / (session.Correct + session.Above + session.Under))
                        );
                    Assert.That(correctPercentage, Is.EqualTo(session.PieChart.CorrectSlice.PercentageNumber), "Session Pie chart 'Correct' slice has incorrect size");
                }

                if (session.Above != 0)
                {
                    int abovePercentage = (int)Math.Round(
                        100 * ((decimal)session.Above / (session.Correct + session.Above + session.Under))
                        );
                    Assert.That(abovePercentage, Is.EqualTo(session.PieChart.AboveSlice.PercentageNumber), "Session Pie chart 'Above' slice has incorrect size");
                }

                if (session.Under != 0)
                {
                    int underPercentage = (int)Math.Round(
                        100 * ((decimal)session.Under / (session.Correct + session.Above + session.Under))
                        );
                    Assert.That(underPercentage, Is.EqualTo(session.PieChart.UnderSlice.PercentageNumber), "Session Pie chart 'Under' slice has incorrect size");
                }
            }
        }

        [When(@"Role ""(.*)"" is selected")]
        public void RoleIsSelected(string role)
        {
            scheduleGraphPage.RolesDropDown.Click();
            scheduleGraphPage.RolesDropDown.WaitToAppear();
            scheduleGraphPage.RolesDropDown.SelectRole(role);
            scheduleGraphPage.RolesDropDown.WaitToDisappear();
        }
    }
}