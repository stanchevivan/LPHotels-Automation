using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace DataSeeding.Hooks
{
    [Binding]
    public class AssignmentsHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public AssignmentsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateMainAssignment", Order = ScenarioStepsOrder.Assignment)]
        public void AssignmenIsCreated()
        {
            var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var mainAssignment = new MainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.HomeDepartmentID = departmentId;
                x.PrimaryRoleID = roleId;
                x.JobTitleID = jobTitle;
            });

            _lpHotelsMainUnitOfWork.StaffPayInfo.Add(mainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(mainAssignment, Constants.Data.MainAssignment);
        }

        [BeforeScenario("CreateMainAssignmentInTheFuture", Order = ScenarioStepsOrder.Assignment)]
        public void FutureMainAssignmen()
        {
            var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var mainAssignment = new MainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.HomeDepartmentID = departmentId;
                x.PrimaryRoleID = roleId;
                x.JobTitleID = jobTitle;
                x.FromDate = DateTime.UtcNow.AddYears(+5);
            });

            _lpHotelsMainUnitOfWork.StaffPayInfo.Add(mainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(mainAssignment, Constants.Data.FutureMainAssignment);
        }

        [BeforeScenario("MainAssignmentForEmployeeAnotherOrganisation", Order = ScenarioStepsOrder.Assignment)]
        public void AssignmenForAnotherOrganisation()
        {
            var roleId = Session.Get<TempRole>(Constants.Data.RoleAnoderOrganisation).ID;
            var departmentId = Session.Get<Department>(Constants.Data.DepartmentAnotherOrganisation).ID;
            var employeeId = Session.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation).ID;
            //var jobTitle = Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var mainAssignment = new MainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.HomeDepartmentID = departmentId;
                x.PrimaryRoleID = roleId;
                //x.JobTitleID = jobTitle;
            });

            _lpHotelsMainUnitOfWork.StaffPayInfo.Add(mainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(mainAssignment, Constants.Data.MainAssignmentAnotherOrganisation);
        }
    }
}
