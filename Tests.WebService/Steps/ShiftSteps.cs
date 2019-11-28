using DataSeeding.Models;
using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.WebService.Steps
{
    [Binding]
    internal class ShiftSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;

        public ShiftSteps(ScenarioContext context, RestSession restSession)
        {
            this.context = context;
            this.restSession = restSession;
        }

        [Given(@"request has a shift as a body")]
        public void GivenRequestHasAShiftAsABody()
        {
            restSession.Request.AddJsonBody(JsonConvert.SerializeObject(context.Get<CreateShiftModel>()));
        }

        [Then(@"the shift is created")]
        public void ThenTheShiftIsCreated()
        {
            var restResponse = restSession.Response;
            var expectedShift = context.Get<CreateShiftModel>();

            Assert.Multiple(()=> 
            {
                Assert.AreEqual(expectedShift.RoleId, restResponse.SelectTokens("RoleId"), "Wrong RoleId");
                Assert.AreEqual(expectedShift.EmployeeId, restResponse.SelectTokens("EmployeeId"), "Wrong employeeId");
            });
        }
    }
}