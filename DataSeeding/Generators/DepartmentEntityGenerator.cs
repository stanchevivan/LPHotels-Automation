using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;
using System;

namespace DataSeeding.Generators
{
    public class DepartmentEntityGenerator : BaseGenerator<Department>
    {
        protected override IEnumerable<Department> BuildModels(int count)
        {
            var departmentFaker = new Faker<Department>().Rules((f, d) =>
            {
                d.Code = f.Database.Random.AlphaNumeric(10);
                d.Name = f.Name.Random.AlphaNumeric(7);
                d.LocationID = RandomGenerator.RandomIntBetween(5,7);
                d.Deleted = false;
                d.HoursAfterMidnightDayCutoff = 5;
                d.StartDate = DateTime.Today.AddDays(-2);
            });

            return departmentFaker.Generate(count);
        }
    }
}
