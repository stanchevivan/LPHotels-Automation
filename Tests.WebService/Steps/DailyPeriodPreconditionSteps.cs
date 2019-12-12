using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Helpers;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Steps;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{[Binding]
    class DailyPeriodPreconditionSteps
    {

        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public DailyPeriodPreconditionSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"create dailyPeriod")]
        public void CreateDailyPeriod(Table table)
        {
            var department = context.Get<Department>(Constants.Data.Department);
           // var anotherDepartmentSameLocation = context.Get<Department>(Constants.Data.AnotherDepartmentSameLocation);
            //var departmentAnotherLocationSameOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation);
            ///var departmentAnotherOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherOrganisation);

            //var dailyPeriod = new DailyPeriod();

            var dailyPeriod = new DailyPeriodEntityGenerator().GenerateSingle( x =>
            {
                x.DepartmentID = department.ID;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), dailyPeriod);

            _lpHotelsMainUnitOfWork.DailyPeriod.Add(dailyPeriod);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(dailyPeriod, Constants.Data.DailyPeriods);
        }
    }
}
