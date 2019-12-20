using System.Collections.Generic;
using System.Linq;
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
            var dailyPeriod = new DailyPeriodEntityGenerator().GenerateSingle( x =>
            {
                x.DepartmentID = department.ID;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), dailyPeriod);

            _lpHotelsMainUnitOfWork.DailyPeriod.Add(dailyPeriod);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(dailyPeriod, Constants.Data.DailyPeriods);
        }

        [Given(@"create dailyPeriods")]
        public void CreateDailyPeriods()
        {
            var department = context.Get<Department>(Constants.Data.Department);

            var dailyPeriods = new List<DailyPeriod>();
            var dailyPeriod1 = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.StartMins = 300;
                x.EndMins = 720;
                x.Name = "Breakfast";
            });
            dailyPeriods.Add(dailyPeriod1);

            var dailyPeriod2 = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.StartMins = 720;
                x.EndMins = 1080;
                x.Name = "Lunch";
            });
            dailyPeriods.Add(dailyPeriod2);

            var dailyPeriod3 = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.StartMins = 1080;
                x.EndMins = 1740;
                x.Name = "Dinner";
            });
            dailyPeriods.Add(dailyPeriod3);

            //GeneralHelpers.SetValues(table.CreateSet<Parameters>(), dailyPeriods);


            _lpHotelsMainUnitOfWork.DailyPeriod.AddRange(dailyPeriods);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(dailyPeriods, Constants.Data.DailyPeriods);
        }
    }
}
