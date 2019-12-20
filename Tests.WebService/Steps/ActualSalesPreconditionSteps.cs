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
{
    [Binding]
    class ActualSalesPreconditionSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public ActualSalesPreconditionSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"create actual sales")]
        public void CreateActualSales(Table table)
        {
            var department = context.Get<Department>(Constants.Data.Department);
            var salesTypes = context.Get<List<SalesType>>(Constants.Data.SalesTypes)[0];

            var actualSalesAllSessions = new List<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL>();

            var actualSalesFirstSession = new ActualSalesEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.SalesTypeID = salesTypes.ID;
                x.StartHour = 5;
                x.Sales = 30;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), actualSalesFirstSession);
            actualSalesAllSessions.Add(actualSalesFirstSession);

            var actualSalesSecondSession = new ActualSalesEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.SalesTypeID = salesTypes.ID;
                x.StartHour = 12;
                x.Sales = 50;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), actualSalesSecondSession);
            actualSalesAllSessions.Add(actualSalesSecondSession);


            var actualSalesThirdSession = new ActualSalesEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = department.ID;
                x.SalesTypeID = salesTypes.ID;
                x.StartHour = 18;
                x.Sales = 60;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), actualSalesThirdSession);
            actualSalesAllSessions.Add(actualSalesThirdSession);

            
            _lpHotelsMainUnitOfWork.ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL.AddRange(actualSalesAllSessions);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(actualSalesAllSessions, Constants.Data.ActualSales);
        }
    }   
}
