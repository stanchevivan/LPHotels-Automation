using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TechTalk.SpecFlow;
using TeamHours.DomainModel;
using DataSeeding.Framework;
using Common;

namespace DataSeeding.Hooks
{
    [Binding]
    public class DepartmentsHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public DepartmentsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateDepartment", Order = ScenarioStepsOrder.Department)]
        public void DepartmentIsCreated()
        {
            var locationId = Session.Get<Location>(Constants.Data.Location).ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(department, Constants.Data.Department);
        }

        [BeforeScenario("CreateDepartmentAnotherLocationSameOrganisation", Order = ScenarioStepsOrder.Department)]
        public void DepartmentAnotherLocationSameOrganisationIsCreated()
        {
            var locationId = Session.Get<List<Location>>(Constants.Data.Locations)[2].ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(department, Constants.Data.DepartmentAnotherLocationSameOrganisation);
        }

        [BeforeScenario("CreateDepartmentAnotherOrganisation", Order = ScenarioStepsOrder.Department)]
        public void DepartmentAnotherOrganisationIsCreated()
        {
            var locationId = Session.Get<Location>(Constants.Data.LocationAnotherOrganisation).ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(department, Constants.Data.DepartmentAnotherOrganisation);
        }
    }
}