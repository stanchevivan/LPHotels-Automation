using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Helpers;
using Newtonsoft.Json;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Steps;
using NUnit.Framework;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{
    [Binding]
    public class ShiftPreconditionSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public ShiftPreconditionSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"create and save shift in db")]
        [When(@"create and save shift in db")]
        public void CreateAndSaveShift(Table table)
        {
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var roleId = context.Get<TempRole>(Constants.Data.Role).ID;

            //var shift = context.Get<TempShift>(Constants.Data.Shift);
            var createShift = new TempShift();
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShift);
            createShift.DepartmentID = departmentId;
            //createShift.ChargedDate = DateTime.UtcNow;
            createShift.TempStaffID = employeeId;
            createShift.Actual = true;
            createShift.TempRoleID = roleId;
            //restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
            //restSession.Client.Execute(restSession.Request);
            _lpHotelsMainUnitOfWork.TempShift.Add(createShift);
            _lpHotelsMainUnitOfWork.SaveAsync();
            context.Set(createShift, Constants.Data.Shift);
        }

        [Given(@"shift for depatment with (.*) is created and saved into database")]
        public void ShiftsForAnotherOrganisation(string data)
        {
            switch (data)
            {
                case "sameLocationSameOrganisation":
                    var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
                    var departmentId = context.Get<Department>(Constants.Data.Department).ID;
                    var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;

                    var shift = new ShiftEntityGenerator().GenerateSingle(x =>
                    {
                        x.DepartmentID = departmentId;
                        x.TempStaffID = employeeId;
                        x.TempRoleID = roleId;
                    });
                    _lpHotelsMainUnitOfWork.TempShift.Add(shift);
                    _lpHotelsMainUnitOfWork.SaveAsync();
                    context.Set(shift, Constants.Data.Shift);
                    break;

                case "anotherLocationSameOrganisation":
                    var roleIdAnotherLocation = context.Get<TempRole>(Constants.Data.Role).ID;
                    var departmentIdAnotherLocation = context.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation).ID;
                    var employeeIdAnotherLocation = context.Get<TempStaff>(Constants.Data.Employee).ID;

                    var shiftAnotherLocation = new ShiftEntityGenerator().GenerateSingle(x =>
                    {
                        x.DepartmentID = departmentIdAnotherLocation;
                        x.TempStaffID = employeeIdAnotherLocation;
                        x.TempRoleID = roleIdAnotherLocation;
                    });
                    _lpHotelsMainUnitOfWork.TempShift.Add(shiftAnotherLocation);
                    _lpHotelsMainUnitOfWork.SaveAsync();
                    context.Set(shiftAnotherLocation, Constants.Data.ShiftAnotherLocationSameOrganisation);
                    break;

                case "locationAnotherOrganisation":
                    var roleIdAnotherOrganisation = context.Get<TempRole>(Constants.Data.RoleAnoderOrganisation).ID;
                    var departmentIdAnotherOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherOrganisation).ID;
                    var employeeIdAnotherOrganisation = context.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;

                    var shiftAnotherOrganisation = new ShiftEntityGenerator().GenerateSingle(x =>
                    {
                        x.DepartmentID = departmentIdAnotherOrganisation;
                        x.TempStaffID = employeeIdAnotherOrganisation;
                        x.TempRoleID = roleIdAnotherOrganisation;
                    });
                    _lpHotelsMainUnitOfWork.TempShift.Add(shiftAnotherOrganisation);
                    _lpHotelsMainUnitOfWork.SaveAsync();
                    context.Set(shiftAnotherOrganisation, Constants.Data.ShiftLocationAnotherOrganisation);
                    break;

                case "sameLocationAnotherDepartment":
                    var roleIdAnotherDepartment = context.Get<TempRole>(Constants.Data.Role).ID;
                    var departmentIdSameLocation = context.Get<Department>(Constants.Data.AnotherDepartmentSameLocation).ID;
                    var employee = context.Get<TempStaff>(Constants.Data.Employee).ID;

                    var shiftAnotherDepartment = new ShiftEntityGenerator().GenerateSingle(x =>
                    {
                        x.DepartmentID = departmentIdSameLocation;
                        x.TempStaffID = employee;
                        x.TempRoleID = roleIdAnotherDepartment;
                    });
                    _lpHotelsMainUnitOfWork.TempShift.Add(shiftAnotherDepartment);
                    _lpHotelsMainUnitOfWork.SaveAsync();
                    context.Set(shiftAnotherDepartment, Constants.Data.ShiftSameLocationAnotherDepartment);
                    break;
            }
        }



        [Given(@"Shift is created to be imported with invalid data (.*)")]
        public void ShiftIsCreatedToBeImportedWithInvalidRole(string invalidData, Table table)
        {
            switch (invalidData)
            {
                case "shiftWithInvalidEmployeeId":
                    var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
                    var createShiftwithInvalidemployee = new DataSeeding.Models.CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftwithInvalidemployee);
                    createShiftwithInvalidemployee.RoleId = roleId;
                    createShiftwithInvalidemployee.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    context.Set(createShiftwithInvalidemployee, Constants.Data.Shift);
                    break;

                case "shiftWithInvalidRoleId":
                    var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
                    var createShiftwithInvalidRole = new DataSeeding.Models.CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftwithInvalidRole);
                    createShiftwithInvalidRole.EmployeeId = employeeId;
                    createShiftwithInvalidRole.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    context.Set(createShiftwithInvalidRole, Constants.Data.Shift);
                    break;

                case "shiftWithEmployeeFromAnotherOrganisation":
                    var roleIdForShift = context.Get<TempRole>(Constants.Data.Role).ID;
                    var employeeIdAnotherOrganisation = context.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;
                    var createShiftAnotherOrganisationEmployee = new DataSeeding.Models.CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftAnotherOrganisationEmployee);
                    createShiftAnotherOrganisationEmployee.EmployeeId = employeeIdAnotherOrganisation;
                    createShiftAnotherOrganisationEmployee.RoleId = roleIdForShift;
                    createShiftAnotherOrganisationEmployee.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    context.Set(createShiftAnotherOrganisationEmployee, Constants.Data.Shift);
                    break;

                case "shiftWithRoleFromAnotherOrganisation":
                    var roleIdForAnotherOrganisation = context.Get<TempRole>(Constants.Data.RoleAnoderOrganisation).ID;
                    var employeeIdForShift = context.Get<TempStaff>(Constants.Data.Employee).ID;
                    var createShiftAnotherOrganisationRole = new DataSeeding.Models.CreateShiftModel();
                    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftAnotherOrganisationRole);
                    createShiftAnotherOrganisationRole.EmployeeId = employeeIdForShift;
                    createShiftAnotherOrganisationRole.RoleId = roleIdForAnotherOrganisation;
                    createShiftAnotherOrganisationRole.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
                    context.Set(createShiftAnotherOrganisationRole, Constants.Data.Shift);
                    break;
            }
        }



        //[Given(@"get actual shiftId (.*) from db")]
        //public void ShiftsIdFromDb(string data)
        //{
        //    switch (data)
        //    {
        //        case "sameLocationSameOrganisation":
        //            var shift = context.Get<TempShift>(Constants.Data.Shift);
        //            var shif1t = context.Get<TempShift>(Constants.Data.Shift).ID;
        //            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == shift.Notes).First();
        //            Session.Set(actualShift, Constants.Data.Shift, true);
        //            break;

        //        case "anotherShift":
        //            var anotherShift = context.Get<TempShift>(Constants.Data.AnotherShift);
        //            var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == anotherShift.Notes).First();
        //            Session.Set(dbShift, Constants.Data.Shift, true);
        //            break;
        //    }
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
        [When(@"Error (.*) should be returned")]
        [Then(@"Error (.*) should be returned")]
        public void CorrectErrorShouldBeReturned(string errorMessage)
        {
            var restResponse = restSession.Response.Content;           
            Assert.True(restResponse.Contains(errorMessage));
        }
    }



}

        //[Given(@"shift for depatment in another organisation is created and saved into database")]
        //public void ShiftsForAnotherOrganisation()
        //{
        //    var roleIdAnotherOrganisation = Session.Get<TempRole>(Constants.Data.RoleAnoderOrganisation).ID;
        //    var departmentIdAnotherOrganisation = Session.Get<Department>(Constants.Data.DepartmentAnotherOrganisation).ID;
        //    var employeeIdAnotherOrganisation = Session.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;

        //    var shift = new ShiftEntityGenerator().GenerateSingle(x =>
        //    {
        //        x.DepartmentID = departmentIdAnotherOrganisation;
        //        x.TempStaffID = employeeIdAnotherOrganisation;
        //        x.TempRoleID = roleIdAnotherOrganisation;
        //    });

        //    _lpHotelsMainUnitOfWork.TempShift.Add(shift);
        //    _lpHotelsMainUnitOfWork.SaveAsync();

        //    Session.Set(shift, Constants.Data.AnotherOrganisationShift);
        //}
  

