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
            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            });
            Session.Set(shift, Constants.Data.Shift);
        }

        [When(@"Create Shift endpoint is requested to create shift for given location and department")]
        public void ShiftEndpointIsRequestedToCreateShiftForTheGivenLocation()
        {
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var shiftToImport = Session.Get<TempShift>(Constants.Data.Shift);
            var response = _shiftsFacade.CreateShift(locationId, departmentId, shiftToImport);
            Session.SetResponse(response);
        }

        [Given(@"Shift Entity is updated to be imported")]
        public void ShiftEntityIsUpdatedToBeImported()
        {
            var shiftEntity = Session.Get<TempShift>(Constants.Data.Shift);
            shiftEntity.Notes = shiftEntity.Notes + "Upadated";
            Session.Set(shiftEntity, Constants.Data.UpdatedShift);
        }

        [When(@"Update Shift endpoint is requested")]
        public void UpdateShiftEndpointIsRequested()
        {
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var shiftToUpdate = Session.Get<TempShift>(Constants.Data.UpdatedShift);
            var response = _shiftsFacade.UpdateShift(locationId, departmentId, shiftId, shiftToUpdate);
            Session.SetResponse(response);
        }

        [When(@"Delete Shift endpoint is requested")]
        public void DeleteShiftEndpointIsRequested()
        {
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var response = _shiftsFacade.DeleteShift(locationId, departmentId, shiftId);
            Session.SetResponse(response);
        }
    }
}
