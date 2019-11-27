using System.Linq;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TechTalk.SpecFlow;

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

        [Given(@"(.*)locations are created and saved into database")]
        public void LocationsAreCreated(int count)
        {
            var organisationId = 1;//Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var locations = new LocationEntityGenerator().GenerateMultiple(count, x =>
            {
                x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = organisationId;
            }).ToList();

            _lpHotelsMainUnitOfWork.Location.AddRange(locations);
            //_lpHotelsMainUnitOfWork.Location.RemoveRange(Locations);
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

        [Given(@"Location for another organisation is created and saved into database")]
        public void LocationsForAnotherOrganisationAreCreated()
        {
            var organisationId = 159;//Session.Get<OrganisationEntity>(Constants.Data.);

            var location = new LocationEntityGenerator().GenerateSingle(x =>
            {
                x.Name = "LocationAnotherOrganisation";
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.Location.Add(location);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(location, Constants.Data.LocationAnotherOrganisation);

        }

        [Given(@"(.*) departments are created and saved into database")]
        public void DepartmentsAreCreated(int count)
        {
            var locationId = 1;//fromsession

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

        [Given(@"Department for another Location in same organisation is created and saved into database")]
        public void DepartmentAnotherLocationSameOrganisation()
        {
            var locationId = 127560;//fromsession

            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(department, Constants.Data.DepartmentAnotherLocationSameOrganisation);
        }

        [Given(@"Department for another organisation is created and saved into database")]
        public void DepartmentAnotherOrganisation()
        {
            var anotherOrganisationLocationId = 127559;//fromsession

            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "DepAnotherOrganisation" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = anotherOrganisationLocationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(department, Constants.Data.DepartmentAnotherOrganisation);
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

        [Given(@"Employee for another Organisation is created and saved into database")]
        public void EmployeeForAnotherOrganisation()
        {
            var organisationId = 159;// Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var employee = new EmployeeEntityGenerator().GenerateSingle( x =>
            {
                x.OrganisationID = organisationId;
                x.Forename = "QaAnotherOrganisation";
            });

            _lpHotelsMainUnitOfWork.TempStaff.Add(employee);
            _lpHotelsMainUnitOfWork.SaveAsync();

                Session.Set(employee, Constants.Data.Employee);
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

        [Given(@"Area for another Organissation is created and saved into database")]
        public void AreasForAnotherOrganisationIsCreated()
        {
            var organisationId = 159;// Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var area = new AreaEntityGenerator().GenerateSingle( x =>
            {
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.TempArea.Add(area);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(area, Constants.Data.Area, true);
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

        [Given(@"Role for another Organisation is created and saved into database")]
        public void RolesAnotherOrganisationIsCreated()
        {
            var anotherOrganisationId = 159;// Session.Get<Organisation>(Constants.Data.Organisation).ID;
            var anotherAreaId = 93025; //Session.Get<TempArea>(Constants.Data.Area).ID;

            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = anotherOrganisationId;
                x.TempAreaID = anotherAreaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(role, Constants.Data.RoleAnoderOrganisation);
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

        [Given(@"JobTitle for another organisation is created and saved into database")]
        public void JobTitleForAnotherOrganisationAreCreated()
        {
            var organisationId = 159;// Session.Get<Organisation>(Constants.Data.Organisation).ID;
            var roleId = 93025;// Session.Get<TempRole>(Constants.Data.Role);
            var jobTitle = new JobTitleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.TempRoleID = roleId;
            });

            _lpHotelsMainUnitOfWork.JobTitle.Add(jobTitle);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(jobTitle, Constants.Data.JobTitle, true);
        }

        [Given(@"MainAssignment is created and saved into database")]
        public void MainassignmentIsCreated()
        {
            var roleId = 184025;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = 189851;//Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = 171848;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = 1193318;// Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

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

        [Given(@"MainAssignment for anoder organisation is created and saved into database")]
        public void MainassignmentAnotherOrganisationIsCreated()
        {
            var roleId = 184029;//Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = 189850;//Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = 171847;//Session.Get<TempStaff>(Constants.Data.Employee).ID;
            var jobTitle = 1193319;// Session.Get<JobTitle>(Constants.Data.JobTitle).ID;

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

        [Given(@"Shift for depatment in another organisation is created and saved into database")]
        public void ShiftsForAnotherOrganisation()
        {
            var roleIdAnotherOrganisation = 184029;//Session.Get<TempRole>(Constants.Data.).ID;
            var departmentIdAnotherOrganisation = 189850;//Session.Get<Department>(Constants.Data.).ID;
            var employeeIdAnotherOrganisation = 171847;//Session.Get<TempStaff>(Constants.Data.Employee).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentIdAnotherOrganisation;
                x.TempStaffID = employeeIdAnotherOrganisation;
                x.TempRoleID = roleIdAnotherOrganisation;
            });

            _lpHotelsMainUnitOfWork.TempShift.Add(shift);
            _lpHotelsMainUnitOfWork.SaveAsync();

             Session.Set(shift, Constants.Data.AnotherOrganisationShift);
        }

        [Given(@"Shift for department in same oraganisation, but in another location, is created and saved into database")]
        public void ShiftsForAnotherLocation()
        {
            var roleId = 1;//Session.Get<TempRole>(Constants.Data.).ID;
            var departmentIdAnotherLocation = 189851;//Session.Get<Department>(Constants.Data.).ID;
            var employeeId = 1;//Session.Get<TempStaff>(Constants.Data.).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentIdAnotherLocation;
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            });

            _lpHotelsMainUnitOfWork.TempShift.Add(shift);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(shift, Constants.Data.AnotherShift);
        }

        [Given(@"Shift for another department in same location is created and saved into database")]
        public void ShiftsForAnotherDepartment()
        {
            var roleIdAnotherDepartment = 1;//Session.Get<TempRole>(Constants.Data.).ID;
            var departmentIdAnotherDepartment = 189851;//Session.Get<Department>(Constants.Data.).ID;
            var employeeIdAnotherDepartment = 1;//Session.Get<TempStaff>(Constants.Data.).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentIdAnotherDepartment;
                x.TempStaffID = employeeIdAnotherDepartment;
                x.TempRoleID = roleIdAnotherDepartment;
            });

            _lpHotelsMainUnitOfWork.TempShift.Add(shift);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(shift, Constants.Data.AnotherShift);
        }
    }
}
