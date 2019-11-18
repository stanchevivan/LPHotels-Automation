using System;
using System.Collections.Generic;
using System.Linq;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace MockAPI
{
    public class MockServer
    {
        private FluentMockServer server;

        public void Start()
        {
            server = FluentMockServer.StartWithAdminInterface(new[] { "http://+:3300" });
            var path = AppDomain.CurrentDomain.BaseDirectory;

            server.ReadStaticMappings($"{path}Mappings");

            Console.WriteLine("STARTED:" + server.IsStarted);
            var mm = server.Mappings;
            foreach (var item in mm)
            {
                Console.WriteLine(item.Path);
            }
            Console.WriteLine(server.Mappings);
        }

        public void MockGet(string path, int status, string response)
        {
            Console.WriteLine("AA AA AA MOCKGET MOCK.API");
            server
                .Given(Request.Create().WithPath(u => u.Contains(path)).UsingAnyMethod())
                .RespondWith(Response.Create()
                    .WithStatusCode(status)
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

        public void Stop()
        {
            server.Stop();
        }
    }
}