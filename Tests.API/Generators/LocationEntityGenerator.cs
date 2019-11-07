using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;

namespace Tests.API.Generators
{
    class LocationEntityGenerator : BaseGenerator<Location>
    {
        public static readonly string CustomerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];

        protected override IEnumerable<Location> BuildModels(int count)
        {
            var locationFaker = new Faker<Location>().Rules((f, l) =>
            {
                l.Code = f.Database.Random.AlphaNumeric(10);
                l.Name = f.Name.Random.AlphaNumeric(7);
                l.Latitude = f.Random.Double();
                l.Longitude = f.Random.Double();
            });

            return locationFaker.Generate(count);
        }
    }
}
