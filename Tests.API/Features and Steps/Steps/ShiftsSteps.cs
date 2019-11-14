using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using TechTalk.SpecFlow;
using Tests.API.Facade;
using Tests.API.Framework;
using Tests.API.Generators;
using TeamHours.DomainModel;

namespace Tests.API.Features_and_Steps.Steps
{
    [Binding]
    public class ShiftsSteps
    {
        private readonly ShiftsFacade _shiftsFacade;

        public ShiftsSteps(ShiftsFacade shiftsFacade)
        {
            _shiftsFacade = shiftsFacade;
        }

        [Given(@"Shift Entity is created to be imported")]
        public void ShiftEntityIsCreatedToBeImported()
        {
            var locationId = 127554;////Session.Get<Location>(Constants.Data.Location).ID;

            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = 189847;//Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentId;
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            });

            Session.Set(shift, Constants.Data.Shift);
        }

        [When(@"Shift endpoint is requested to create shift for the given location")]
        public void ShiftsEndpointIsRequestedToCreateShiftForTheGivenLocation()
        {
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var shiftToImport = Session.Get<TempShift>(Constants.Data.Shift);
            var response = _shiftsFacade.CreateShifts(locationId, departmentId, shiftToImport);
            Session.SetResponse(response);
        }
    }
}
