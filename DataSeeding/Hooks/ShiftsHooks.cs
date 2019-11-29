using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using DataSeeding.Models;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace DataSeeding.Hooks
{
    [Binding]
    public class ShiftsHooks
    {

        private readonly ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork;
        private readonly ScenarioContext context;

        public ShiftsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork, ScenarioContext context)
        {
            this.lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
            this.context = context;
        }

        [BeforeScenario("CreateShift", Order = ScenarioStepsOrder.Shift)]
        public void ShiftIsCreated()
        {
            var roleId = context.Get<TempRole>(Constants.Data.Role).ID;
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;

            var shift = new ShiftEntityGenerator().GenerateSingle(x =>
            {
                x.DepartmentID = departmentId;
                x.TempStaffID = employeeId;
                x.TempRoleID = roleId;
            });

            lpHotelsMainUnitOfWork.TempShift.Add(shift);
            lpHotelsMainUnitOfWork.SaveAsync();
            context.Set(shift, Constants.Data.Shift);
        }

        [BeforeScenario("PostShift", Order = ScenarioStepsOrder.Shift)]
        public void CreateShiftModel()
        {
            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var roleId = context.Get<TempRole>(Constants.Data.Role).ID;

            var createshift = new CreateShiftModel();
            createshift.EmployeeId = employeeId;
            createshift.RoleId = roleId;
            createshift.Notes = RandomGenerator.AlphaNumeric(10) + "QaAutomatioNotes";
            context.Set(createshift, Constants.Data.Shift);
        }
    }
}
