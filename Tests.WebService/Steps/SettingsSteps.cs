using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace Tests.WebService.Steps
{
    [Binding]
    public class SettingsSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public SettingsSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"Daily peroods are created for departments")]
        public void GivenRequestHasAShiftAsABodyWithParameters()
        {
            var department = context.Get<Department>(Constants.Data.Department);
            var anotherDepartmentSameLocation = context.Get<Department>(Constants.Data.AnotherDepartmentSameLocation);
            var departmentAnotherLocationSameOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation);
            var departmentAnotherOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherOrganisation);

            var dailyPeriods = new List<DailyPeriod>();

            var dailyPeriodsCurrentDepartment = new DailyPeriodEntityGenerator().GenerateMultiple(3,x =>
               {
                   x.DepartmentID = department.ID;                   
               }).ToList();
            dailyPeriods.AddRange(dailyPeriodsCurrentDepartment);

            var dailyPeriodsAnotherDepartmentSameLocation = new DailyPeriodEntityGenerator().GenerateSingle( x =>
            {
                x.DepartmentID = anotherDepartmentSameLocation.ID;
            });
            dailyPeriods.Add(dailyPeriodsAnotherDepartmentSameLocation);

            var dailyPeriodsDepartmentAnotherLocationSameOrganisation = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentAnotherLocationSameOrganisation.ID;
            });
            dailyPeriods.Add(dailyPeriodsDepartmentAnotherLocationSameOrganisation);

            var dailyPeriodsdepartmentAnotherOrganisation = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentAnotherOrganisation.ID;
            });
            dailyPeriods.Add(dailyPeriodsdepartmentAnotherOrganisation);


            _lpHotelsMainUnitOfWork.DailyPeriod.AddRange(dailyPeriods);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(dailyPeriodsCurrentDepartment, Constants.Data.DailyPeriods);
        }

        [Then(@"the response should be correct")]
        public void TheResponseShouldBeCorrect()
        {
            var restResponse = restSession.Response;
            var importedDailyPeriods = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods);
            var department = context.Get<Department>(Constants.Data.Department);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(importedDailyPeriods.Count, restResponse.SelectToken("sessions").Count());
                Assert.AreEqual(department.HoursAfterMidnightDayCutoff.ToString(), restResponse.SelectToken("departmentStartDayHour").ToString(), "Wrong Department");
                CollectionAssert.AreEquivalent(importedDailyPeriods.Select(x => x.Name).ToList(), restResponse.SelectToken("sessions").ToList().Select(x => (string)x.SelectToken("name")).ToList(), "Wrong Name");
                CollectionAssert.AreEquivalent(importedDailyPeriods.Select(x => x.StartMins).ToList(), restResponse.SelectToken("sessions").ToList().Select(x => (decimal)x.SelectToken("startTimeMinutes")).ToList(), "Wrong Minutes");
                CollectionAssert.AreEquivalent(importedDailyPeriods.Select(x => x.EndMins).ToList(), restResponse.SelectToken("sessions").ToList().Select(x => (decimal)x.SelectToken("endTimeMinutes")).ToList(), "Wrong Minutes");
            });
        }
    }
}
