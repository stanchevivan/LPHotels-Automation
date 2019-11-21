using System.Collections.Generic;
using Common;
using Fourth.TH.Automation.RestDriver;
using Infrastructure.Security;

namespace Tests.API
{
    public static class RestDriverExtensions
    {
        public static IRequest AddFourthHeaders(this IRequest request)
        {
            var token = "Bearer " + TokenGenerator.Get("lpfh-automationqa", 14019);
            var header = new List<Header>
            {
                new Header
                {
                    Name = Constants.Headers.OrganizationHeader,
                    Value = token
                }
            };

            request.AddHeaders(header);
            return request;
        }
    }
}
