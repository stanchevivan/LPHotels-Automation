using Fourth.Automation.Framework.RestApi.Steps;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace Tests.WebService.Steps
{
    [Binding]
    internal class ShiftSteps
    {
        private readonly RestSession restSession;

        public ShiftSteps(RestSession restSession)
        {
            this.restSession = restSession;
        }

        [Given(@"request has a shift as a body")]
        public void GivenRequestHasAShiftAsABody()
        {
            restSession.Request.AddJsonBody(JsonConvert.SerializeObject(new object()));
        }

        [Then(@"the shift is created")]
        public void ThenTheShiftIsCreated()
        {
        }
    }
}