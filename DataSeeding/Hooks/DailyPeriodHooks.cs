using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace DataSeeding.Hooks
{
    [Binding]
    class DailyPeriodHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;
        private readonly ScenarioContext context;

        public DailyPeriodHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork, ScenarioContext context)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
            this.context = context;
        }

        [BeforeScenario("CreateDailyPeriod", Order = ScenarioStepsOrder.DailyPeriod)]
        public void DailyPeriodIsCreated()
        {
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var dailyPeriod = new DailyPeriodEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentId;
            });

            _lpHotelsMainUnitOfWork.DailyPeriod.Add(dailyPeriod);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(dailyPeriod, Constants.Data.DailyPeriod);
        }

    }
}