using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Helpers;
using Common;
using Common.Helpers;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Extensions;
using Fourth.Automation.Framework.RestApi.Steps;
using Fourth.LabourProductivity.Scheduling.Domain.Scheduling.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static Fourth.Orchestration.Model.Products.Events.CatalogueLoaded.Types;

namespace Tests.WebService.Steps
{
    [Binding]
    class SchedulePeriodSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public SchedulePeriodSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

       [Given(@"create assignments with different roles")]
        public void AssignmentsWithDifferentRoles()
        {
            var roles = Session.Get<List<TempRole>>(Constants.Data.Roles);
            var departmentId = Session.Get<Department>(Constants.Data.Department).ID;
            var employees = Session.Get<List<TempStaff>>(Constants.Data.Employees);
            var jobTitle = Session.Get<JobTitle>(Constants.Data.JobTitle).ID;
            var assignments = new List<StaffPayInfo>();

            var mainAssignments = new MainAssignmentEntityGenerator().GenerateMultiple(5, x =>
            {
                x.HomeDepartmentID = departmentId;
                x.JobTitleID = jobTitle;
            }).ToList();
            for (int i = 0; i < mainAssignments.Count; i++)
            {
                mainAssignments[i].TempStaffID = employees[i].ID;
                mainAssignments[i].PrimaryRoleID = roles[i].ID;
            }
            assignments.AddRange(mainAssignments);
            _lpHotelsMainUnitOfWork.StaffPayInfo.AddRange(mainAssignments);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(mainAssignments, Constants.Data.MainAssignments);
        }

        [Given(@"SchedulePeriod data is created for departments")]
        public void SchedulePeriodsAreCreatedForDepartments(Table table)
        {
            var parameters = table.CreateSet<Parameters>();
            var department = context.Get<Department>(Constants.Data.Department);
            var role = context.Get<TempRole>(Constants.Data.Role);
            var employees = context.Get<List<TempStaff>>(Constants.Data.Employees);
            var employee = context.Get<TempStaff>(Constants.Data.Employee);
            var employeeAnotherorganisation = context.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation);
            var anotherDepartmentSameLocation = context.Get<Department>(Constants.Data.AnotherDepartmentSameLocation);
            var departmentAnotherLocationSameOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation);
            var departmentAnotherOrganisation = context.Get<Department>(Constants.Data.DepartmentAnotherOrganisation);

            var shifts = new List<TempShift>();
            var expectedShifts = new List<TempShift>();
            var expectedEmployees = new List<TempStaff>();

            var shiftsForCurrentDepartment = new ShiftEntityGenerator().GenerateMultiple(3, x =>
            {
                foreach (var parameter in parameters)
                {
                    var param = x.GetType().GetProperty(parameter.Field);
                    var typeToSet = Nullable.GetUnderlyingType(param.PropertyType) ?? param.PropertyType;
                    param.SetValue(x, Convert.ChangeType(parameter.Value, typeToSet));
                    x.DepartmentID = department.ID;
                    x.TempRoleID = role.ID;
                }
            }).ToList();

            for (int i = 0; i < shiftsForCurrentDepartment.Count; i++)
            {
                shiftsForCurrentDepartment[i].TempStaffID = employees[i].ID;
                expectedEmployees.Add(employees[i]);
            }

            shifts.AddRange(shiftsForCurrentDepartment);
            expectedShifts.AddRange(shiftsForCurrentDepartment);

            var shiftsAnotherDepartmentSameLocation = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = anotherDepartmentSameLocation.ID;
                x.TempStaffID = employee.ID;
                x.TempRoleID = role.ID;
                x.StartDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(2);
                x.EndDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(3);
                x.ChargedDate = shiftsForCurrentDepartment.FirstOrDefault().ChargedDate;
            });
            shifts.Add(shiftsAnotherDepartmentSameLocation);
            expectedShifts.Add(shiftsAnotherDepartmentSameLocation);

            var shiftsDepartmentAnotherLocationSameOrganisation = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentAnotherLocationSameOrganisation.ID;
                x.TempStaffID = employee.ID;
                x.TempRoleID = role.ID;
                x.StartDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(4);
                x.EndDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(5);
                x.ChargedDate = shiftsForCurrentDepartment.FirstOrDefault().ChargedDate;
            });
            shifts.Add(shiftsDepartmentAnotherLocationSameOrganisation);
            expectedShifts.Add(shiftsDepartmentAnotherLocationSameOrganisation);

            var shiftsDepartmentAnotherOrganisation = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentAnotherOrganisation.ID;
                x.TempStaffID = employeeAnotherorganisation.ID;
                x.TempRoleID = role.ID;
                x.StartDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(6);
                x.EndDateTime = shiftsForCurrentDepartment.FirstOrDefault().StartDateTime.AddHours(7);
                x.ChargedDate = shiftsForCurrentDepartment.FirstOrDefault().ChargedDate;
            });
            shifts.Add(shiftsDepartmentAnotherOrganisation);

            expectedEmployees.Add(employee);
            expectedEmployees.Add(employeeAnotherorganisation);

            _lpHotelsMainUnitOfWork.TempShift.AddRange(shifts);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(expectedEmployees, Constants.Data.Employees);
            context.Set(expectedShifts, Constants.Data.ExpectedShifts);
        }

        [When(@"response")]
        [Then(@"response")]
        public void test()
        {
            var restResponse = restSession.Response.Content;

            var response = JsonConvert.DeserializeObject<List<ScheduleDto>>(restResponse);

            foreach (var schedule in response)
            {

            }


            var expectedEmployees = context.Get<List<TempStaff>>(Constants.Data.Employees);
            var expectedShifts = context.Get<List<TempShift>>(Constants.Data.ExpectedShifts);
            var expectedRole = context.Get<TempRole>(Constants.Data.Role);

            var expectedRoles = context.Get<List<TempRole>>(Constants.Data.Roles);
            int expectedDays = 4;
            var employeesData = new List<string>();

            //var actualRoles = response.Select(x => x.Roles).ToList();
            //foreach (var role in actualRoles)
            //{
            //    Assert.AreEqual(expectedRole.Name, role.Select(s => s.Value).Select(e => e.RoleName).FirstOrDefault());
            //    Assert.AreEqual(expectedRole.ID, role.Select(s => s.Value).Select(e => e.Id).FirstOrDefault());
            //    Assert.AreEqual(expectedRole.ID, role.Select(s => s.Value).Select(e => e.Id).FirstOrDefault());
            //}





            foreach (var schedule in response)
            {

                foreach (var role in schedule.Roles.Values)
                {
                  //  var expectedRoleEmployeeIds = expectedEmployees.Where(s => s.StaffPayInfoList.First().PrimaryRoleID == role.Id).Select(r => r.ID).ToList();
                    CollectionAssert.AreEquivalent(role.EmployeeIds, expectedRoles.Select(r=> r.ID));
                }

                foreach (var employee in schedule.Employees.Values)
                {
                    var expectedEmployeeShiftIds = expectedShifts.Where(s => s.TempStaffID == employee.Id && s.ChargedDate == schedule.Date).Select(s => s.ID).ToList();
                    CollectionAssert.AreEquivalent(employee.ShiftIds, expectedEmployeeShiftIds);
                }
                var dd =schedule.Employees.Select(e => e.Value).Select(f=> f.LastName);
                    CollectionAssert.AreEquivalent(expectedEmployees.Select(k => k.Surname).ToList(), schedule.Employees.Select(e => e.Value).Select(f => f.LastName));
                    CollectionAssert.AreEquivalent(expectedEmployees.Select(k => k.Forename).ToList(), schedule.Employees.Select(e => e.Value).Select(r => r.FirstName));
                    CollectionAssert.AreEquivalent(expectedEmployees.Select(k => k.ID).ToList(), schedule.Employees.Select(e => e.Value).Select(r => r.Id));
                    CollectionAssert.AreEquivalent(expectedShifts.Select(k => k.ChargedDate).ToList(), schedule.Employees.Select(e => e.Value).Select(r => r.ScheduleDate));

               
            }
            }


            //var roles1 = response[0].Roles.ToList().Select(s => s.Key);

            //var roles3 = response[0].Roles.ToList().Select(s => s.Value).ToList().Select(e => e.Id).FirstOrDefault();
            //var roles4 = response[0].Roles.ToList().Select(s => s.Value).ToList().Select(e => e.RoleName).FirstOrDefault();
            //var roles5 = response[0].Roles.ToList().Select(s => s.Value).Select(e => e.Symbol).FirstOrDefault();
            //var roles9 = response[0].Roles.Select(s => s.Value).Select(e => e.Symbol);
            //var roles6 = response[0].Roles.ToList().Select(s => s.Value).ToList().Select(e => e.ScheduleDate);
            //var roles8 = response[0].Roles.ToList().Select(s => s.Value).Select(e => e.ScheduleDate);
            //var roles7 = response[0].Roles.ToList().Select(s => s.Value).ToList().Select(e => e.EmployeeIds).ToList();
            // foreach (var role in )
            // var rr3 = a[0].SelectToken("date").ToString();

            //var role = a[0].SelectToken("roles").SelectToken("184739").SelectToken("roleName").ToString();
            //var employee = a[0].SelectToken("employees").SelectToken("172853").SelectToken("shiftIds").ToList();
            // var vvv =( a.Select(z=> z.SelectToken("employees").SelectToken(expectedEmployees).SelectToken("lastName").ToString()).ToList());
            //for (int i = 0;i< expectedEmployees.Count; i++)
            //{
            //    var employee = a[i].SelectToken("employees").SelectToken(expectedEmployees[i].ID.ToString()).SelectToken("lastName").ToString();
            //    employeesData.Add(employee);
            ////}
            //var datesList = new List<string>();
            //var rolesList = new List<string>();
            //var rolesNameList = new List<string>();
            //var rolesIdList = new List<string>();
            //var rolesScheduleDateList = new List<string>();
            //var rolesEmployees = new List<string>();
            //var employeeIdList = new List<string>();

            //for (int j = 0; j < 3; j++)
            //{
            //    for (int i = 0; i < expectedEmployees.Count; i++)
            //    {
            //        //DateList
            //        var date = a[j].SelectToken("date").ToString();
            //        datesList.Add(date);


            //        //RoleLists
            //        var roleName = a[i].SelectToken("roles").SelectToken(expectedRoles.ID.ToString()).SelectToken("roleName").ToString();
            //        rolesNameList.Add(roleName);

            //        var roleId = a[i].SelectToken("roles").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        rolesIdList.Add(roleId);

            //        var roleScheduleDate = a[i].SelectToken("roles").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        rolesIdList.Add(roleScheduleDate);

            //        var roleEmployees = a[i].SelectToken("roles").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        rolesEmployees.Add(roleEmployees);

            //        //EmployeeLists

            //        //var roleName = a[i].SelectToken("employees").SelectToken(expectedRoles.ID.ToString()).SelectToken("roleName").ToString();
            //        rolesNameList.Add(roleName);

            //        var employeeId = a[i].SelectToken("employees").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        employeeIdList.Add(roleId);

            //        //var roleScheduleDate = a[i].SelectToken("employees").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        rolesIdList.Add(roleScheduleDate);

            //        //var roleEmployees = a[i].SelectToken("employees").SelectToken(expectedRoles.ID.ToString()).SelectToken("id").ToString();
            //        rolesEmployees.Add(roleEmployees);


            //    }


        }


        //var dates = a.Select(d => (string)d.SelectToken("dates")).GetType().GetProperties().ToList();
        //var dates2 = a.SelectToken("dates").ToString();
        //var dates3 = a.Select(d => d.SelectToken("employees")).ToString();

        //Assert.Multiple(() =>
        //{
        //});
    }


    //[Given(@"create assignment")]
    //public void FutureMainAssignmen(Table table)
    //{
    //    var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
    //    var departmentId = context.Get<Department>(Constants.Data.Department).ID;
    //    var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
    //    var jobTitle = context.Get<JobTitle>(Constants.Data.JobTitle).ID;
    //    var parameters = table.CreateSet<Parameters>();

    //     var mainAssignment = new MainAssignmentEntityGenerator().GenerateSingle(x =>
    //    {
    //        foreach (var parameter in parameters)
    //        {
    //            x.TempStaffID = employeeId;
    //            x.HomeDepartmentID = departmentId;
    //            x.PrimaryRoleID = roleId;
    //            x.JobTitleID = jobTitle;
    //        }
    //    });
    //    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), mainAssignment);

    //    _lpHotelsMainUnitOfWork.StaffPayInfo.Add(mainAssignment);
    //    _lpHotelsMainUnitOfWork.SaveAsync();

    //    context.Set(mainAssignment, Constants.Data.FutureMainAssignment);
    //}

    //[Given(@"request has a shift as a body with parameters")]
    //public void GivenRequestHasAShiftAsABodyWithParameters(Table table)
    //{
    //    var shift = context.Get<CreateShiftModel>(Constants.Data.ShiftModel);
    //    GeneralHelpers.SetValues(table.CreateSet<Parameters>(), shift);
    //    restSession.Request.AddJsonBody(JsonConvert.SerializeObject(shift));
    //    restSession.Client.Execute(restSession.Request);
    //}



