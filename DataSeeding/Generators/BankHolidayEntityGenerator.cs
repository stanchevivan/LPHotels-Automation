using System;
using System.Collections.Generic;
using System.Configuration;
using Bogus;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    public class BankHolidayEntityGenerator : BaseGenerator<BankHoliday>
    {
        public static readonly string CustomerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];

        protected override IEnumerable<BankHoliday> BuildModels(int count)
        {
            var bankFaker = new Faker<BankHoliday>().Rules((f, b) =>
            {
                b.Date = DateTime.UtcNow;
                b.Name = "test";
                b.LocationID = 1313;


            });

            return bankFaker.Generate(count);
        }
    }
}