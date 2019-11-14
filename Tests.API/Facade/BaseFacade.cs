using Fourth.TH.Automation.RestDriver;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infrastructure.Security;

namespace Tests.API.Facade
{
    public class BaseFacade
    {
        protected readonly IRestDriver Driver;

        public BaseFacade(IRestDriver driver)
        {
            Driver = driver;
        }

        protected IRequest Request { get; set; }

        public IRequest BuildRequest()
        {
            return Request
                .AddFourthHeaders();
        }
    }
}
