using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamHours.DomainModel;
using Common;
using Fourth.TH.Automation.RestDriver;
using Newtonsoft.Json;

namespace Tests.API.Facade
{
    public class ShiftsFacade : BaseFacade
    {
        public ShiftsFacade(IRestDriver driver) : base(driver)
        {
            Request = Driver.CreateRequest();
        }

        public IResponse CreateShifts(string locationId, string departmentId, TempShift shift)
        {
            return BuildRequest()
                .AddResource(Constants.Enpoints.Locations)
                .AddResource(locationId)
                .AddResource(Constants.Enpoints.Departments)
                .AddResource(departmentId)
                .AddResource(Constants.Enpoints.Shifts)
                .AddJsonBodyParameter(JsonConvert.SerializeObject(shift))
                .Post()
                .ExecuteRequest();

        }
    }
}
