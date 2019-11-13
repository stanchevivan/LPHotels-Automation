using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fourth.TH.Automation.RestDriver;

namespace Tests.API.Facade
{
    public class ShiftsFacade : BaseFacade
    {
        public ShiftsFacade(IRestDriver driver) : base(driver)
        {
            Request = Driver.CreateRequest();
        }

       // public IResponse GetShifts(string)
    }
}
