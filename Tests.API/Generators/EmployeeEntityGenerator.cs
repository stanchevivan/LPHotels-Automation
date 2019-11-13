using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace Tests.API.Generators
{
    public class EmployeeEntityGenerator : BaseGenerator<TempStaff>
    {
        //public static readonly string CustomerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];

        protected override IEnumerable<TempStaff> BuildModels(int count)
        {
            var employeeFaker = new Faker<TempStaff>().Rules((f, l) =>
            {
                l.Forename = "QaAutomation" + RandomGenerator.AlphaNumeric(7);
                l.Surname = f.Name.Random.AlphaNumeric(7);
                l.Phone = RandomGenerator.OnlyNumeric(10);
                l.EmailAddress = RandomGenerator.OnlyNumeric(10) + "@" + RandomGenerator.OnlyNumeric(5)+ ".com";
                l.DateOfBirth = DateTime.UtcNow.AddYears(-30);
                l.PersonnelNumber = RandomGenerator.OnlyNumeric(10);
            });

            return employeeFaker.Generate(count);
        }
    }
}
