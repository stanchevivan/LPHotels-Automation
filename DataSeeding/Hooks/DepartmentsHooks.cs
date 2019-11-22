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

        //[AfterScenario("CreateDepartment", Order = ScenarioStepsOrder.Department)]
        //public async Task DeleteDepartment()
        //{
        //    var departmentToDelete = Session.Get<Department>(Constants.Data.Department);
        //    _lpHotelsMainUnitOfWork.Department.Remove(departmentToDelete);
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}