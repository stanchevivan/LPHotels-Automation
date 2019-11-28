using System.Collections.Generic;

namespace Infrastructure.Security
{
    public static class TokenGenerator
    {
        public static string Get(string subdomain, int userId)
        {
            return new JwtGenerator(new JwtConfiguration() { })
                .Generate(new Dictionary<string, object>
                    { { ClaimKey.Subdomain, subdomain }, { ClaimKey.UserId, userId } });
        }
    }
}
