using System.Configuration;

namespace Infrastructure.Security
{
    internal class JwtConfiguration
    {
        public string Secret => ConfigurationManager.AppSettings["jwt_shared_secret"];
    }
}
