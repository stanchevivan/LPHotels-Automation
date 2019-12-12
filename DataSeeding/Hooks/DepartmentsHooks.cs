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
        private readonly ScenarioContext context;

        public DepartmentsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork, ScenarioContext context)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
            this.context = context;
        }

        [BeforeScenario("CreateDepartment", Order = ScenarioStepsOrder.Department)]
        public void DepartmentIsCreated()
        {
            var locationId = context.Get<Location>(Constants.Data.Location).ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(department, Constants.Data.Department);
        }

        [BeforeScenario("CreateAnotherDepartmentSameLocation", Order = ScenarioStepsOrder.Department)]
        public void AnotherDepartmentSameLocation()
        {
            var locationId = context.Get<Location>(Constants.Data.Location).ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(department, Constants.Data.AnotherDepartmentSameLocation);
        }

        [BeforeScenario("CreateDepartmentAnotherLocationSameOrganisation", Order = ScenarioStepsOrder.Department)]
        public void DepartmentAnotherLocationSameOrganisationIsCreated()
        {
            var locationId = context.Get<List<Location>>(Constants.Data.Locations)[2].ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(department, Constants.Data.DepartmentAnotherLocationSameOrganisation);
        }

        [BeforeScenario("CreateDepartmentAnotherOrganisation", Order = ScenarioStepsOrder.Department)]
        public void DepartmentAnotherOrganisationIsCreated()
        {
            var locationId = context.Get<Location>(Constants.Data.LocationAnotherOrganisation).ID;
            var department = new DepartmentEntityGenerator().GenerateSingle(d =>
            {
                d.Name = "TestDep" + RandomGenerator.OnlyNumeric(2);
                d.LocationID = locationId;
            });

            _lpHotelsMainUnitOfWork.Department.Add(department);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(department, Constants.Data.DepartmentAnotherOrganisation);
        }

       // [AfterScenario("CreateDepartment", Order = ScenarioStepsOrder.Department)]
        public void DeleteDepartment()
        {
            var departmentToDelete = context.Get<Department>(Constants.Data.Department);
            _lpHotelsMainUnitOfWork.Department.Attach(departmentToDelete);
            _lpHotelsMainUnitOfWork.Department.Remove(departmentToDelete);
            _lpHotelsMainUnitOfWork.SaveAsync();
        }
    }
}