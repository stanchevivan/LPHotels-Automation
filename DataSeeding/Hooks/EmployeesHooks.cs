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
    public class EmployeesHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public EmployeesHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateEmployee", Order = ScenarioStepsOrder.Employee)]
        public void EmployeeIsCreated()
        {
            var organisationId = Common.Constants.OgranisationId;
            var employee = new EmployeeEntityGenerator().GenerateSingle( x =>
            {
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.TempStaff.Add(employee);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(employee, Constants.Data.Employee, true);
        }

        [BeforeScenario("CreateAnotherOrganisationEmployee", Order = ScenarioStepsOrder.Employee)]
        public void EmployeeAnotherOrganisationIsCreated()
        {
            var organisationId = Constants.AnotherOgranisationId;
            var employee = new EmployeeEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.TempStaff.Add(employee);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(employee, Constants.Data.EmployeeAnotherOrganisation);
        }
    }
}

