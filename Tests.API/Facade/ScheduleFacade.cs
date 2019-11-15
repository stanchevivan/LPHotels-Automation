using TeamHours.DomainModel;
using Common;
using Fourth.TH.Automation.RestDriver;
using Newtonsoft.Json;
using System;

namespace Tests.API.Facade
{
    public class ScheduleFacade : BaseFacade
    {
        public ScheduleFacade(IRestDriver driver) : base(driver)
        {
            Request = Driver.CreateRequest();
        }

        public IResponse GetSchedule(string locatinId, string departmentId, string fromDate, string toDate)
        {
            return BuildRequest()
                .AddResource(Constants.Enpoints.Locations)
                .AddResource(locatinId)
                .AddResource(Constants.Enpoints.Departments)
                .AddResource(departmentId)
                .AddResource(Constants.Enpoints.From)
                .AddResource(fromDate)
                .AddResource(Constants.Enpoints.To)
                .AddResource(toDate)
                .AddResource(Constants.Enpoints.SchedulePeriod)
                .Get()
                .ExecuteRequest();
        }
    }
}
