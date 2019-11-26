using System;
using System.Linq;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace MockAPI
{
    public class MockServer
    {
        private readonly FluentMockServer server;

        public MockServer()
        {
            //server = FluentMockServer.StartWithAdminInterface(new[] { "https://+:3300" });
            server = FluentMockServer.Start(3300);
            var path = AppDomain.CurrentDomain.BaseDirectory;

            server.ReadStaticMappings($"{path}Mappings");

            Console.WriteLine("STARTED:" + server.IsStarted);
        }

        public void MockGet(string path, int status, string response)
        {
            server
                .Given(Request.Create().WithPath(u => u.Contains(path)).UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(status)
                    .WithHeader("Content-Type", "application/json")
                    .WithBody(response));
        }

        public void MockPost(string path, int status, string body, string response)
        {
            server
                .Given(Request.Create().WithPath(u => u.Contains(path)).UsingPost()
                .WithBody(b => b.Contains(body)))
                .RespondWith(Response.Create()
                    .WithStatusCode(status)
                    .WithHeader("Content-Type", "application/json")
                    .WithBody(response));
        }
    }
}