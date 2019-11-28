using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Infrastructure.Security;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Tests.WebService.Hooks
{
    [Binding]
    internal class Hook
    {
        private const string RESET_HEADER = "9abdc4a5-7d84-4533-a61b-6a01d386700e";
        private readonly RestSession restSession;
        public Hook(RestSession restSession)
        {
            this.restSession = restSession;
        }

        [BeforeScenario]
        public void AuthenticationHook()
        {
            var organisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];
            var token = $"Bearer {TokenGenerator.Get(organisationSubdomain, 14019)}";
            var headers = new Dictionary<string, string>()
            {
                {"Authorization", token },
                {"reset", RESET_HEADER }
            };
            restSession.Client.AddDefaultHeaders(headers);
        }
    }
}