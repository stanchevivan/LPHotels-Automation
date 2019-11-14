using System.Linq;
using Common;
using Infrastructure.Security;
using TechTalk.SpecFlow;
using Tests.API.Framework;
using Tests.API.Generators;
using Tests.API.Infrastructure;
using TeamHours.DomainModel;

namespace Tests.API.Features_and_Steps.PreconditionSteps
{
    [Binding]
    public class PreconditionSteps
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public PreconditionSteps(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"(.*) locations are created and saved into database")]
        public void LocationsAreCreated(int count)
        {
            //var organisation = Session.Get<OrganisationEntity>(Constants.Data.Organization);
            var organisation = 123;

            var locations = new LocationEntityGenerator().GenerateMultiple(count, x =>
            {
                x.Name = "ShouldBeReturned" + RandomGenerator.OnlyNumeric(2);
            }).ToList();

            locations.ForEach(x => x.OrganisationID = 1);
            _lpHotelsMainUnitOfWork.Location.AddRange(locations);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(locations.First(), Constants.Data.Location, true);
            }
            else
            {
                Session.Set(locations, Constants.Data.Locations, true);
            }
        }

        [Given(@"(.*) departments are created and saved into database")]
        public void DepartmentsAreCreated(int count)
        {
            var locationId = 1;

            var departments = new DepartmentEntityGenerator().GenerateMultiple(count, d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            }).ToList();

            _lpHotelsMainUnitOfWork.Department.AddRange(departments);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(departments.First(), Constants.Data.Department, true);
            }
            else
            {
                Session.Set(departments, Constants.Data.Departments, true);
            }
        }

        [Given(@"(.*) employees are created and saved into database")]
        public void EmployeeAreCreated(int count)
        {
            //var organisation = Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var employees = new EmployeeEntityGenerator().GenerateMultiple(count, x =>
            {
                x.OrganisationID = 1;
            }).ToList();

            _lpHotelsMainUnitOfWork.TempStaff.AddRange(employees);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(employees.First(), Constants.Data.Employee, true);
            }
            else
            {
                Session.Set(employees, Constants.Data.Employees, true);
            }
        }

        [Given(@"(.*) areas are created and saved into database")]
        public void AreasAreCreated(int count)
        {
            //var organisation = Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var areas = new AreaEntityGenerator().GenerateMultiple(count, x =>
            {
                x.OrganisationID = 1;//organisation
            }).ToList();

            _lpHotelsMainUnitOfWork.TempArea.AddRange(areas);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(areas.First(), Constants.Data.Area, true);
            }
            else
            {
                Session.Set(areas, Constants.Data.Areas, true);
            }
        }

        [Given(@"(.*) roles are created and saved into database")]
        public void RolesAreCreated(int count)
        {
            //var organisation = Session.Get<Organisation>(Constants.Data.Organisation).ID;
            //var areaId = Session.Get<TempArea>(Constants.Data.Area).ID;
            //var name = Session.Get<JobTitle>(Constants.Data.JobTitle).Name;

            var roles = new RoleEntityGenerator().GenerateMultiple(count, x =>
            {
                x.OrganisationID = 1;//organisation
                x.TempAreaID = 93020;//areaId
            }).ToList();

            _lpHotelsMainUnitOfWork.TempRole.AddRange(roles);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(roles.First(), Constants.Data.Role, true);
            }
            else
            {
                Session.Set(roles, Constants.Data.Roles, true);
            }
        }

        [Given(@"(.*) jobTitles are created and saved into database")]
        public void JobTitlesAreCreated(int count)
        {
            //var organisation = Session.Get<Organisation>(Constants.Data.Organisation).ID;
            //var role = Session.Get<TempRole>(Constants.Data.Role);
            //var roleId = role.ID;
           // var roleName = role.Name;

            var jobTitles = new JobTitleEntityGenerator().GenerateMultiple(count, x =>
            {
                x.OrganisationID = 1;//organisation
                x.TempRoleID = 184025;//roleId
            }).ToList();

            _lpHotelsMainUnitOfWork.JobTitle.AddRange(jobTitles);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(jobTitles.First(), Constants.Data.JobTitle, true);
            }
            else
            {
                Session.Set(jobTitles, Constants.Data.JobTitles, true);
            }
        }

        [Given(@"MainAssignment is created and saved into database")]
        public void MainassignmentIsCreated()
        {
            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = 189847;//Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = 1193317;// Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

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

        [Given(@"(.*) shifts are created and saved into database")]
        public void ShiftsAreCreated(int count)
        {
            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = 189847;//Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = 171832;//Session.Get<TempStaff>(Constants.Data.Employee).ID;

            var shifts = new ShiftEntityGenerator().GenerateMultiple(count, x =>
            {
                x.DepartmentID = departmentId;
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            }).ToList();

            _lpHotelsMainUnitOfWork.TempShift.AddRange(shifts);
            _lpHotelsMainUnitOfWork.SaveAsync();

            if (count == 1)
            {
                Session.Set(shifts.First(), Constants.Data.Shift, true);
            }
            else
            {
                Session.Set(shifts, Constants.Data.Shifts, true);
            }
        }
    }
}
