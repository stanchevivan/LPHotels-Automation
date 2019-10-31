using System;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LPHotels.Automation.Support
{
    [Binding]
    public class MockHooks
    {
        private ScenarioContext scenarioContext;

        public MockHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        MockAPI.MockServer server;
        bool shouldMockGet;
        bool shouldMockPost;

        string path;
        int status;
        string body;
        string response;

        [BeforeScenario(Order = 1)]
        public void StartMockServer()
        {
            server = new MockAPI.MockServer();
        }

        [BeforeScenario(Order = 999)]
        public void DoMock()
        {
            if (shouldMockGet)
            {
                server.MockGet(path, status, response);
            }

            if (shouldMockPost)
            {
                server.MockPost(path, status, body, response);
            }
        }

        [BeforeScenario, Scope(Tag ="MockInvalidLocations")]
        public void MockLocations()
        {
            path = "/Locations";
            response = "INVALID RESPONSE";
            status = 402;

            shouldMockGet = true;
        }

        [BeforeScenario, Scope(Tag = "MockValidSave")]
        public void MockSave()
        {
            path = "/Locations";
            body = "POST VALID BODY";
            response = "VALID RESPONSE";
            status = 402;

            shouldMockPost = true;
        }
    }
}