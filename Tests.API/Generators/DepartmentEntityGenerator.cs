using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace Tests.API.Generators
{
    class DepartmentEntityGenerator : BaseGenerator<Department>
    {
        public static readonly string CustomerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];

        protected override IEnumerable<Department> BuildModels(int count)
        {
            var locationFaker = new Faker<Department>().Rules((f, d) =>
            {
                d.Code = f.Database.Random.AlphaNumeric(10);
                d.Name = f.Name.Random.AlphaNumeric(7);
                d.LocationID = RandomGenerator.RandomIntBetween(5,7);
                d.Deleted = false;
                d.HoursAfterMidnightDayCutoff = 5;
            });

            return locationFaker.Generate(count);
        }
    }
}
