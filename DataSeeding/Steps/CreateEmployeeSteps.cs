using System.Linq;
using TechTalk.SpecFlow;
using Tests.API.Infrastructure;
using Tests.API.Generators;
using Tests.API.Framework;
using Common;

namespace DataSeeding.Steps

{
    [Binding]
    public class CreateEmployeeSteps
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public CreateEmployeeSteps(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
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
    }
}