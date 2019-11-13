using System.Linq;
using Common;
using Infrastructure.Security;
using TechTalk.SpecFlow;
using Tests.API.Framework;
using Tests.API.Generators;
using Tests.API.Infrastructure;

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
    }
}
