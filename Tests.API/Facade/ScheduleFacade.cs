using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fourth.TH.Automation.RestDriver;

namespace Tests.API.Facade
{
    public class ScheduleFacade : BaseFacade
    {
        public ScheduleFacade(IRestDriver driver) : base(driver)
        {
            Request = Driver.CreateRequest();
        }
    }
}
