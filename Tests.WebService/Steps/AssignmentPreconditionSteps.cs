using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Helpers;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Steps;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{
    [Binding]
    public class AssignmentPreconditionSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public AssignmentPreconditionSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"create non main assignment")]
        public void CreateNonMainAssignment(Table table)
        {
            var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = context.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var nonMainAssignment = new NonMainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                    x.TempStaffID = employeeId;
                    x.DepartmentID = departmentId;
                    x.RoleID = roleId;
                    x.JobTitleID = jobTitle;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), nonMainAssignment);

            _lpHotelsMainUnitOfWork.AdditionalRole.Add(nonMainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(nonMainAssignment, Constants.Data.FutureMainAssignment);
        }

        [Given(@"create assignment")]
        public void FutureMainAssignmen(Table table)
        {
            var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = context.Get<JobTitle>(Constants.Data.JobTitle).ID;
            var mainAssignment = new MainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                    x.TempStaffID = employeeId;
                    x.HomeDepartmentID = departmentId;
                    x.PrimaryRoleID = roleId;
                    x.JobTitleID = jobTitle;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), mainAssignment);

            _lpHotelsMainUnitOfWork.StaffPayInfo.Add(mainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(mainAssignment, Constants.Data.NonMainAssignment);
        }

        [Given(@"create non main assignment for another department, same location")]
        public void CreateNonMainAssignmentAnotherDepartment(Table table)
        {
            var roleId = context.Get<TempRole>(Constants.Data.AnotherRole).ID;
            var departmentId = context.Get<Department>(Constants.Data.AnotherDepartmentSameLocation).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = context.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var nonMainAssignment = new NonMainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.DepartmentID = departmentId;
                x.RoleID = roleId;
                x.JobTitleID = jobTitle;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), nonMainAssignment);

            _lpHotelsMainUnitOfWork.AdditionalRole.Add(nonMainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(nonMainAssignment, Constants.Data.NonMainAssignment);
        }

        [Given(@"create non main assignment for another location, same organisation")]
        public void CreateNonMainAssignmentAnotherlocationSameOrganisation(Table table)
        {
            var roleId = context.Get<TempRole>(Constants.Data.AnotherRole).ID;
            var departmentId = context.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = context.Get<JobTitle>(Constants.Data.JobTitle).ID;

            var nonMainAssignment = new NonMainAssignmentEntityGenerator().GenerateSingle(x =>
            {
                x.TempStaffID = employeeId;
                x.DepartmentID = departmentId;
                x.RoleID = roleId;
                x.JobTitleID = jobTitle;
            });
            GeneralHelpers.SetValues(table.CreateSet<Parameters>(), nonMainAssignment);

            _lpHotelsMainUnitOfWork.AdditionalRole.Add(nonMainAssignment);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(nonMainAssignment, Constants.Data.NonMainAssignment);
        }
    }
}
