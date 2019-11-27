using System.Collections.Generic;
using System.Configuration;
using Common;
using DataSeeding.Framework;
using Fourth.TH.Automation.RestDriver;
using Infrastructure.Security;
using TeamHours.DomainModel;

namespace Tests.API
{
    public static class RestDriverExtensions
    {
        public static readonly string OrganisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];
        public static IRequest AddFourthHeaders(this IRequest request)
        {
            var token = "Bearer " + TokenGenerator.Get(OrganisationSubdomain, 14019);
            var header = new List<Header>
            {
                new Header
                {
                    Name = Constants.Headers.OrganizationHeader,
                    Value = token
                },
                new Header
                {
                    Name = Constants.Headers.Reset,
                    Value = "9abdc4a5-7d84-4533-a61b-6a01d386700e"
                }
            };

            request.AddHeaders(header);
            return request;
        }
    }
}
