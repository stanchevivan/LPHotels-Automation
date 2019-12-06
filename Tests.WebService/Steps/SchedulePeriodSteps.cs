using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSeeding.Infrastructure;
using DataSeeding.Models;
using Fourth.Automation.Framework.RestApi.Steps;
using TechTalk.SpecFlow;

namespace Tests.WebService.Steps
{
    [Binding]
    class SchedulePeriodSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public SchedulePeriodSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        //[Given(@"request has a shift as a body with parameters")]
        //public void GivenRequestHasAShiftAsABodyWithParameters(Table table)
        //{
        //    var shift = context.Get<CreateShiftModel>(Constants.Data.ShiftModel);
        //    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), shift);
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
        //    restSession.Client.Execute(restSession.Request);
        //}
    }
}
