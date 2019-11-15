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

        public IResponse CreateShift(string locationId, string departmentId, TempShift shift)
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
        
        public IResponse UpdateShift(string locationId, string departmentId, string shiftId, TempShift shift)
        {
            return BuildRequest()
                .AddResource(Constants.Enpoints.Locations)
                .AddResource(locationId)
                .AddResource(Constants.Enpoints.Departments)
                .AddResource(departmentId)
                .AddResource(Constants.Enpoints.Shifts)
                .AddResource(shiftId)
                .AddJsonBodyParameter(JsonConvert.SerializeObject(shift))
                .Put()
                .ExecuteRequest();

        }

        public IResponse DeleteShift(string locationId, string departmentId, string shiftId)
        {
            return BuildRequest()
                .AddResource(Constants.Enpoints.Locations)
                .AddResource(locationId)
                .AddResource(Constants.Enpoints.Departments)
                .AddResource(departmentId)
                .AddResource(Constants.Enpoints.Shifts)
                .AddResource(shiftId)
                .Delete()
                .ExecuteRequest();

        }
    }
}
