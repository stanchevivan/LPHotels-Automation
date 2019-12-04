using System.Data.Entity;
using System.Linq;
using Common;
using Common.Helpers;
using DataSeeding.Framework;
using DataSeeding.Infrastructure;
using DataSeeding.Models;
using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Newtonsoft.Json;
using NUnit.Framework;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{
    [Binding]
    internal class ShiftsSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public ShiftsSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"request has a shift as a body with parameters")]
        [When(@"request has a shift as a body with parameters")]
        [Then(@"request has a shift as a body with parameters")]
        public void GivenRequestHasAShiftAsABodyWithParameters(Table table)
        {
            var shift = context.Get<CreateShiftModel>(Constants.Data.ShiftModel);
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), shift);
            restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
            restSession.Client.Execute(restSession.Request);
        }

        [Given(@"request has a body with EmployeeAnotherOrganisatoin")]
        public void GivenRequestHasAShiftAsABodyInvalidEmployee(Table table)
        {
            var roleIdForShift = context.Get<TempRole>(Constants.Data.Role).ID;
            var employeeIdAnotherOrganisation = context.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;
            var createShiftAnotherOrganisationEmployee = new DataSeeding.Models.CreateShiftModel();
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), createShiftAnotherOrganisationEmployee);
            createShiftAnotherOrganisationEmployee.EmployeeId = employeeIdAnotherOrganisation;
            createShiftAnotherOrganisationEmployee.RoleId = roleIdForShift;
            createShiftAnotherOrganisationEmployee.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
            context.Set(createShiftAnotherOrganisationEmployee, Constants.Data.Shift);
        }

        [Given(@"request has a body with parameters(.*)")]
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

        //[Given(@"request has a body with parameters")]
        //public void test(Table table)
        //{
        //   // var shift = context.Get<CreateShiftModel>("Employee");
        //    GeneralHelpers.SetValues(table.CreateSet<Parameters>());
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
        //    restSession.Client.Execute(restSession.Request);
        //}

        //[Given(@"request has a body with parameters")]
        //public void RequestHasABodyWithEmployee( Table table)
        //{

        //    var body = context.Get<CreateShiftModel>(Constants.Data.Shift);

        //    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), body);
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(body));
        //    restSession.Client.Execute(restSession.Request);
        //}

        //[Given(@"request has a body with EmployeeId for Another Organisation")]
        //public void RequestHasABodyWithEmployeeFromAnotherOrganisation()
        //{
        //    var employeeId = context.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;
        //    var body = context.Get<DeleteShiftModel>(Constants.Data.ShiftModel);
        //    body.EmployeeId = employeeId;
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(body));
        //    restSession.Client.Execute(restSession.Request);//to be deleted
        //}



        //[Given(@"request has a body with EmployeeId")]
        //public void RequestHasABodyWithEmployeeId()
        //{
        //    var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
        //    var body = context.Get<DeleteShiftModel>(Constants.Data.ShiftModel);
        //    body.EmployeeId = employeeId;
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(body));
        //    restSession.Client.Execute(restSession.Request);//to be deleted
        //}

        [Given(@"request has a body with parameters")]
        public void RequestHasABodyWithEmployeeId(Table table)
        {
            var deleteShift = new DeleteShiftModel();
            //var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
             GeneralHelpers.SetValues(table.CreateSet<Parameters>(), deleteShift);
            // var body = context.Get<DeleteShiftModel>(Constants.Data.ShiftModel);
            //body.EmployeeId = employeeId;
            restSession.Request.AddJsonBody(deleteShift);
            restSession.Client.Execute(restSession.Request);//to be deleted
        }

        //[Given(@"request has a body to be test2")]
        //public void RequestHasABodyWithEmployeetestddd(Table table)
        //{
        //    var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
        //    var body = context.Get<DeleteShiftModel>(Constants.Data.ShiftModelD);
        //    body.EmployeeId = employeeId;
        //    // GeneralHelpers.SetValues(table.CreateSet<Parameters>(), body);
        //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(body));
        //    restSession.Client.Execute(restSession.Request);
        //}

        //[Given(@"get actual shiftIdAnotherOrganisation from db")]
        //public void GetShiftIdAnotherOrganisationFromDb()
        //{
        //    var shift = context.Get<TempShift>(Constants.Data.AnotherOrganisationShift);
        //    var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == shift.Notes).First();
        //    Session.Set(actualShift, Constants.Data.Shift, true);
        //}

        //[Given(@"get actual shiftId from db")]
        //public void GetShiftIdFromDb()
        //{
        //    var shift = context.Get<TempShift>(Constants.Data.Shift);
        //    var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == shift.Notes).First();
        //    Session.Set(actualShift, Constants.Data.Shift, true);
        //}
        [When(@"the shift is created")]
        [Then(@"the shift is created")]
        public void ThenTheShiftIsCreated()
        {
            var restResponse = restSession.Response;
            var expectedShift = context.Get<CreateShiftModel>(Constants.Data.ShiftModel);

            Assert.Multiple(()=> 
            {
                Assert.AreEqual(expectedShift.RoleId.ToString(), restResponse.SelectToken("roleId").ToString(), "Wrong RoleId");
                Assert.AreEqual(expectedShift.EmployeeId.ToString(), restResponse.SelectToken("employeeId").ToString(), "Wrong employeeId");
            });
        }

        [When(@"shift should be deleted from db")]
        [Then(@"shift should be deleted from db")]
        public void ShiftShouldBeDeleted()
        {
            var restResponse = restSession.Response;
            var expectedShift = Session.Get<TempShift>(Constants.Data.Shift);
            var actualShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().AsNoTracking().FirstOrDefault(x => x.Notes == expectedShift.Notes);
            Assert.IsNull(actualShift, Constants.ErrorMessages.UnexpectedRecordInDatabase);
        }
    }
}