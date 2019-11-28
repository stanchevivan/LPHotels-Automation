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
    public class ShiftsHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public ShiftsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateShift", Order = ScenarioStepsOrder.Shift)]
        public void ShiftIsCreated()
        {
            var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = Session.Get<Department>(Constants.Data.Department).ID;
            var employeeId = Session.Get<TempStaff>(Constants.Data.Employee).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentId;
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            });

            _lpHotelsMainUnitOfWork.TempShift.Add(shift);
            _lpHotelsMainUnitOfWork.SaveAsync();
            Session.Set(shift, Constants.Data.Shift);
        }
    }
}
