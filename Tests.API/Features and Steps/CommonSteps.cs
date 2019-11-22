using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using DataSeeding.Framework;

namespace Tests.API.Features_and_Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"The status code of the response should be (.*)")]
        [When(@"The status code of the response should be (.*)")]
        [Then(@"The status code of the response should be (.*)")]
        public void ThenTheStatusCodeOfTheResponseShouldBe(int statusCode)
        {
            var response = Session.GetResponse();
            var actualStatusCode = response.StatusCodeNumber;
            var expectedStatusCode = statusCode;
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }
    }
}
