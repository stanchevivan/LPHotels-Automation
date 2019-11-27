using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using TechTalk.SpecFlow;
using Tests.API.Facade;
using DataSeeding.Framework;
using DataSeeding.Generators;
using TeamHours.DomainModel;
using Tests.API.Models;
using DataSeeding.Infrastructure;
using System.Data.Entity;
using NUnit.Framework;
using System.Globalization;
using Common.Helpers;
using System.Dynamic;
using System.Activities.Expressions;
using TechTalk.SpecFlow.Assist;
using DataSeeding.Framework;
using DataSeeding.Infrastructure;
using DataSeeding.Models;

namespace Tests.API.Features_and_Steps.Steps
{
    [Binding]
    public class ShiftsSteps
    {
        private readonly ShiftsFacade _shiftsFacade;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;


        public ShiftsSteps(ShiftsFacade shiftsFacade, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _shiftsFacade = shiftsFacade;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"Shift is created to be imported")]
        public void ShiftEntityIsCreatedToBeImported()
        {
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var shift = new DataSeeding.Models.CreateShiftModel
            {
                EmployeeId = employeeId,
                RoleId = roleId,
                Break1Minutes = RandomGenerator.RandomIntBetween(1, 10),
                Break2Minutes = RandomGenerator.RandomIntBetween(1, 10),
                ShiftTypeId = 0,
                Notes = RandomGenerator.AlphaNumeric(5) + "QANotes",
                StartDateTime = DateTime.UtcNow,
                EndDateTime = DateTime.UtcNow.AddHours(2)
            };
            Session.Set(shift, Constants.Data.Shift);
        }

        [When(@"Shift is deleted")]
        public void ShiftEntityIsxxxx()
        {
            if (Session.Get<CreateShiftModel>(Constants.Data.Shift) != null)
            {
                var notes = Session.Get<CreateShiftModel>(Constants.Data.Shift).Notes;
                var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
                _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            }

            if (Session.Get<UpdateShiftModel>(Constants.Data.Shift) != null)
            {
                var notes = Session.Get<UpdateShiftModel>(Constants.Data.Shift).Notes;
                var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
                _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            }

            _lpHotelsMainUnitOfWork.SaveAsync();
        }

        [Given(@"Shift is updated to be imported")]
        public void ShiftEntityIsUpdatedToBeImported()
        {
            var importedShift = Session.Get<TempShift>(Constants.Data.Shift);
            var shiftId = importedShift.ID.ToString();
            UpdateShiftModel updatedShift = new UpdateShiftModel
            {
                EmployeeId = importedShift.TempStaffID,
                RoleId = importedShift.TempRoleID,
                Break1Minutes = importedShift.Break1DurationInMinutes,
                Break2Minutes = importedShift.Break2DurationInMinutes,
                ShiftTypeId = 0,
                Notes = importedShift.Notes + "Updated",
                StartDateTime = importedShift.StartDateTime,
                EndDateTime = importedShift.StartDateTime.AddHours(2),
                ChangeReason = RandomGenerator.AlphaNumeric(10),
            };
            Session.Set(updatedShift, Constants.Data.UpdatedShift);
        }

        [When(@"Update Shift endpoint is requested")]
        public void UpdateShiftEndpointIsRequested()
        {
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var shiftToUpdate = Session.Get<UpdateShiftModel>(Constants.Data.UpdatedShift);
            var response = _shiftsFacade.UpdateShift(locationId, departmentId, shiftId, shiftToUpdate);
            Session.SetResponse(response);
        }

        [When(@"Delete Shift endpoint is requested")]
        public void DeleteShiftEndpointIsRequested()
        {
            var shiftToDelete = Session.Get<DeleteShiftModel>(Constants.Data.ShiftToDelete);
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
            var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
            var response = _shiftsFacade.DeleteShift(locationId, departmentId, shiftId, shiftToDelete);
            Session.SetResponse(response);
        }

        [Given(@"Delete Shift model is created to be imported")]
        public void ShiftEntityIsCreatedToBeDeleted()
        {
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var shiftToDelete = new DeleteShiftModel
            {
                EmployeeId = employeeId,
                Reason = "QAToBeDELETED"
            };
            Session.Set(shiftToDelete, Constants.Data.ShiftToDelete);
        }

        [Given(@"Delete Shift model is created with employeeId from another organisation")]
        public void ShiftEntityIsCreatedWithEmployeeIdFromAnotherOrganisation()
        {
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var shiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
            var shiftToDelete = new DeleteShiftModel
            {
                EmployeeId = employeeId,
                Reason = "QAToBeDELETED"
            };
            Session.Set(shiftToDelete, Constants.Data.ShiftToDelete);
        }

        [Then(@"Created shift should be added in the db")]
        public void CreatedShiftShouldBeAddedInDB()
        {
            var expectedShift = Session.Get<CreateShiftModel>(Constants.Data.Shift);
            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().AsNoTracking().FirstOrDefault(x => x.Notes == expectedShift.Notes);
            Assert.NotNull(actualShift);
            Assert.AreEqual(expectedShift.RoleId, actualShift.TempRoleID, "Wrong roleId");
            Assert.AreEqual(expectedShift.EmployeeId, actualShift.TempStaffID, "Wrong employeeId");
            Assert.AreEqual(expectedShift.Notes, actualShift.Notes, "Wrong notes");
            Assert.AreEqual(expectedShift.Break1Minutes, actualShift.Break1DurationInMinutes, "Wrong break");
            Assert.AreEqual(expectedShift.Break2Minutes, actualShift.Break2DurationInMinutes, "Wrong break");
            //Assert.AreEqual(expectedShift.StartDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture), actualShift.StartDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture), "Wrong start");
            //Assert.AreEqual(expectedShift.EndDateTime, actualShift.EndDateTime, "Wrong end");
        }

        [Then(@"Shift should be deleted from db")]
        public void ShiftShouldBeDeleted()
        {
            var response = Session.GetResponse().GetData<ExpandoObject>();
            var responseKeyList = response.Select(x => x.Key).ToList();
            var responseValueList = response.Select(x => x.Value).ToList();
            var expectedShift = Session.Get<TempShift>(Constants.Data.Shift);
            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().AsNoTracking().FirstOrDefault(x => x.Notes == expectedShift.Notes);
            Assert.IsNull(actualShift, Constants.ErrorMessages.UnexpectedRecordInDatabase);
            Assert.AreEqual(responseKeyList[0], "errors");
            Assert.AreEqual(responseKeyList[1], "success");
            Assert.AreEqual(responseKeyList[2], "shift");
            Assert.AreEqual(responseValueList[1].ToString(), "True");
            Assert.IsNull(responseValueList[2]);
        }

        [Then(@"Shift should be updated in the db")]
        public void ShiftShouldBeUpdatedInDB()
        {
            var expectedShift = Session.Get<UpdateShiftModel>(Constants.Data.UpdatedShift);
            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().AsNoTracking().FirstOrDefault(x => x.Notes == expectedShift.Notes);
            Assert.AreEqual(expectedShift.RoleId, actualShift.TempRoleID, "Wrong roleId");
            Assert.AreEqual(expectedShift.EmployeeId, actualShift.TempStaffID, "Wrong employeeId");
            Assert.AreEqual(expectedShift.Notes, actualShift.Notes, "Wrong notes");
            Assert.AreEqual(expectedShift.Break1Minutes, actualShift.Break1DurationInMinutes, "Wrong break");
            Assert.AreEqual(expectedShift.Break2Minutes, actualShift.Break2DurationInMinutes, "Wrong break");
            //Assert.AreEqual(expectedShift.StartDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture), actualShift.StartDateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture), "Wrong start");
            //Assert.AreEqual(expectedShift.EndDateTime, actualShift.EndDateTime, "Wrong end");
        }

        [Given(@"NewShift is created to be imported")]
        [When(@"NewShift is created to be imported")]
        public void NewShiftIsCreatedToBeImported(Table table)
        {
            var employeeId = Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;

            var createshift = new CreateShiftModel();
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createshift);
            createshift.EmployeeId = employeeId;
            createshift.RoleId = roleId;
            createshift.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
            Session.Set(createshift, Constants.Data.Shift, true);
        }

        [Then(@"Error (.*) should be returned")]
        public void CorrectErrorShouldBeReturned(string errorMessage)
        {
            var response = Session.GetResponse().GetData<ExpandoObject>();
            //var responseKeyList = response.Select(x => x.Key).ToList();
            var responseErrorValue = response.Select(x => x.Value).ToList()[0].ToString();
            //var actualErrorMessage = string.Empty;

            //if (errorValue != string.Empty)
            //{
            //    actualErrorMessage = response.GetError().Message.ToString();
            //}

            Assert.AreEqual(responseErrorValue, errorMessage);
        }

        [Then(@"Shift should not be added in the db")]
        public void ShiftShouldNOtBeAddedInDB()
        {
            var response = Session.GetResponse().GetData<ExpandoObject>();
            var responseKeyList = response.Select(x => x.Key).ToList();
            var responseValueList = response.Select(x => x.Value).ToList();
            var expectedShift = Session.Get<CreateShiftModel>(Constants.Data.Shift);
            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().AsNoTracking().FirstOrDefault(x => x.Notes == expectedShift.Notes);
            Assert.IsNull(actualShift, Constants.ErrorMessages.UnexpectedRecordInDatabase);
        }

        [Given(@"Shift is created to be imported with invalid data (.*)")]
        public void ShiftIsCreatedToBeImportedWithInvalidRole(string invalidData, Table table)
        {
            switch (invalidData)
            {
                case "shiftWithInvalidEmployeeId":
                    var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;
                    var createShiftwithInvalidemployee = new CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftwithInvalidemployee);
                    createShiftwithInvalidemployee.RoleId = roleId;
                    createShiftwithInvalidemployee.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    Session.Set(createShiftwithInvalidemployee, Constants.Data.Shift);
                    break;

                case "shiftWithInvalidRoleId":
                    var employeeId = Session.Get<TempStaff>(Constants.Data.Employee).ID;
                    var createShiftwithInvalidRole = new CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftwithInvalidRole);
                    createShiftwithInvalidRole.EmployeeId = employeeId;
                    createShiftwithInvalidRole.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    Session.Set(createShiftwithInvalidRole, Constants.Data.Shift);
                    break;

                case "shiftWithEmployeeFromAnotherOrganisation":
                    var roleIdForShift = Session.Get<TempRole>(Constants.Data.Role).ID;
                    var employeeIdAnotherOrganisation = Session.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;
                    var createShiftAnotherOrganisationEmployee = new CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftAnotherOrganisationEmployee);
                    createShiftAnotherOrganisationEmployee.EmployeeId = employeeIdAnotherOrganisation;
                    createShiftAnotherOrganisationEmployee.RoleId = roleIdForShift;
                    createShiftAnotherOrganisationEmployee.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    Session.Set(createShiftAnotherOrganisationEmployee, Constants.Data.Shift);
                    break;

                case "shiftWithRoleFromAnotherOrganisation":
                    var roleIdForAnotherOrganisation = Session.Get<TempRole>(Constants.Data.RoleAnoderOrganisation).ID;
                    var employeeIdForShift = Session.Get<TempStaff>(Constants.Data.Employee).ID;
                    var createShiftAnotherOrganisationRole = new CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftAnotherOrganisationRole);
                    createShiftAnotherOrganisationRole.EmployeeId = employeeIdForShift;
                    createShiftAnotherOrganisationRole.RoleId = roleIdForAnotherOrganisation;
                    createShiftAnotherOrganisationRole.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    Session.Set(createShiftAnotherOrganisationRole, Constants.Data.Shift);
                    break;
            }
        }

        [Given(@"Create Shift endpoint is requested with (.*) and (.*)")]
        [When(@"Create Shift endpoint is requested with (.*) and (.*)")]
        public void CreateShiftEndpointIsRequested(string data, string id)
        {
            var shiftToImport = new CreateShiftModel();
            var departmentId = "";
            var locationId ="";
            switch (data)
            {
                case "InvalidLocationId":
                    var departmentId1 = Session.Get<Department>(Constants.Data.Department).ID.ToString();
                    var responseInvalidLocation = _shiftsFacade.CreateShift(id, departmentId, shiftToImport);
                    Session.SetResponse(responseInvalidLocation);
                    break;

                case "LocationFromAnatherOrganisation":
                    locationId = Session.Get<Location>(Constants.Data.LocationAnotherOrganisation).ID.ToString();
                    departmentId = Session.Get<Department>(Constants.Data.Department).ID.ToString();
                    var responseLocationAnotherOrg = _shiftsFacade.CreateShift(locationId, departmentId, shiftToImport);
                    Session.SetResponse(responseLocationAnotherOrg);
                    break;

                case "DepartmentFromAnatherOrganisation":
                    locationId = Session.Get<Location>(Constants.Data.Location).ID.ToString();
                    departmentId = Session.Get<Department>(Constants.Data.DepartmentAnotherOrganisation).ID.ToString();
                    var responseDepartmentAnotherOrg = _shiftsFacade.CreateShift(locationId, departmentId, shiftToImport);
                    Session.SetResponse(responseDepartmentAnotherOrg);
                    break;

                case "DepartmentFromAnatherLocationSameOrganisation":
                    locationId = Session.Get<Location>(Constants.Data.Location).ID.ToString();
                    departmentId = Session.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation).ID.ToString();
                    var responseDepartmentAnotherLocSameOrg = _shiftsFacade.CreateShift(locationId, departmentId, shiftToImport);
                    Session.SetResponse(responseDepartmentAnotherLocSameOrg);
                    break;

                case "InvalidDepartmentId":
                    locationId = Session.Get<Location>(Constants.Data.Location).ID.ToString();
                    var responseInvalidDepartment = _shiftsFacade.CreateShift(id, id, shiftToImport);
                    Session.SetResponse(responseInvalidDepartment);
                    break;

                case "CorrectData":
                    shiftToImport = Session.Get<CreateShiftModel>(Constants.Data.Shift);
                    var correctLocationId = Session.Get<Location>(Constants.Data.Location).ID.ToString();
                    var correctDepartmentId = Session.Get<Department>(Constants.Data.Department).ID.ToString();
                    var response = _shiftsFacade.CreateShift(correctLocationId, correctDepartmentId, shiftToImport);
                    Session.SetResponse(response);
                    break;
            }
        }

        [Given(@"Delete Shift endpoint is requested with (.*) and (.*)")]
        [When(@"Delete Shift endpoint is requested with (.*) and (.*)")]
        public void DeleteShiftEndpointIsRequested(string data, string id)
        {
            switch (data)
            {
                case "InvalidLocationId":
                    var shiftIdLocCase = RandomGenerator.OnlyNumeric(7);
                    var shiftToImportDummyLocCase = new DeleteShiftModel();
                    var departmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
                    var responseInvalidLocation = _shiftsFacade.DeleteShift(id, departmentId, shiftIdLocCase, shiftToImportDummyLocCase);
                    //GeneralHelpers.SetValues(table.CreateSet<Parameters>(), responseInvalidLocation);
                    Session.SetResponse(responseInvalidLocation);
                    break;

                case "InvalidDepartmentId":
                    var shiftIdDepCase = RandomGenerator.OnlyNumeric(7);
                    var shiftToImportDummyDepCase = new DeleteShiftModel();
                    var locationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
                    var responseInvalidDepartment = _shiftsFacade.DeleteShift(locationId, id, shiftIdDepCase, shiftToImportDummyDepCase);
                    Session.SetResponse(responseInvalidDepartment);
                    break;

                case "InvalidShiftId":
                    var shiftToImport = Session.Get<DeleteShiftModel>(Constants.Data.Shift);
                    var locationIdFromSession = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
                    var departmentIdFromSession = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
                    var responseInvalidShift = _shiftsFacade.DeleteShift(locationIdFromSession, departmentIdFromSession, id, shiftToImport);
                    Session.SetResponse(responseInvalidShift);
                    break;

                case "CorrectData":
                    var validShiftId = Session.Get<TempShift>(Constants.Data.Shift).ID.ToString();
                    var correctShiftToImport = Session.Get<DeleteShiftModel>(Constants.Data.Shift);
                    var correctLocationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
                    var correctDepartmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
                    var response = _shiftsFacade.DeleteShift(correctLocationId, correctDepartmentId, validShiftId, correctShiftToImport);
                    Session.SetResponse(response);
                    break;

                case "ShiftFromAnotherOrganisation":
                    var anotherOrganisationShiftId = Session.Get<TempShift>(Constants.Data.AnotherOrganisationShift).ID.ToString();
                    var ShiftToImport = Session.Get<DeleteShiftModel>(Constants.Data.Shift);
                    var LocationId = 127554.ToString();////Session.Get<Location>(Constants.Data.Location).ID;
                    var DepartmentId = 189847.ToString();//Session.Get<Department>(Constants.Data.Department).ID;
                    var responseAnotherORganisationShiftId = _shiftsFacade.DeleteShift(LocationId, DepartmentId, anotherOrganisationShiftId, ShiftToImport);
                    Session.SetResponse(responseAnotherORganisationShiftId);
                    break;
            }
        }
    }
}
