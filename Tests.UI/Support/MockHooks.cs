using System;
using TechTalk.SpecFlow;

namespace LPHotels.Automation.Support
{
    [Binding]
    public class MockHooks
    {
        private ScenarioContext scenarioContext;
        private readonly MockAPI.MockServer server;

        public MockHooks(ScenarioContext scenarioContext, MockAPI.MockServer server)
        {
            this.scenarioContext = scenarioContext;
            this.server = server;
        }

        bool shouldMockGet;
        bool shouldMockPost;

        string path;
        int status;
        string body;
        string response;

        [BeforeScenario(Order = 1)]
        public void StartMockServer()
        {
            //server.Start();
        }

        [BeforeScenario(Order = 999)]
        public void DoMock()
        {
            //if (shouldMockGet)
            //{
                //Console.WriteLine("AA AA AA SERVER DOMOCK");
                //server.MockGet(path, status, response);
            //}

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

        [BeforeScenario(Order = 500), Scope(Tag = "MockGet")]
        public void MockGet()
        {
            Console.WriteLine("AA AA AA MOCKGET HOOK");
            path = "http://localhost:3300/locations/2/departments/2/from/2019-03-07/to/2019-03-09/schedule-period";
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

        [AfterScenario]
        public void AfterScenario()
        {
            //server.Stop();
        }
    }
}