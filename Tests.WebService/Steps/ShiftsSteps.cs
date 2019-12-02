using Common.Helpers;
using DataSeeding.Models;
using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{
    [Binding]
    internal class ShiftsSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;

        public ShiftsSteps(ScenarioContext context, RestSession restSession)
        {
            this.context = context;
            this.restSession = restSession;
        }

        [Given(@"request has a shift as a body with parameters")]
        public void GivenRequestHasAShiftAsABodyWithParameters(Table table)
        {
            var shift = context.Get<CreateShiftModel>("Shift");
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), shift);
            restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
        }

        [Then(@"the shift is created")]
        public void ThenTheShiftIsCreated()
        {
            var restResponse = restSession.Response;
            var expectedShift = context.Get<CreateShiftModel>("Shift");

            Assert.Multiple(()=> 
            {
                Assert.AreEqual(expectedShift.RoleId.ToString(), restResponse.SelectToken("shift.roleId").ToString(), "Wrong RoleId");
                Assert.AreEqual(expectedShift.EmployeeId.ToString(), restResponse.SelectToken("shift.employeeId").ToString(), "Wrong employeeId");
            });
        }
    }
}