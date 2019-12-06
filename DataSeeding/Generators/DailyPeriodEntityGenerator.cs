using System;
using System.Collections.Generic;
using Bogus;
using Common;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    public class DailyPeriodEntityGenerator : BaseGenerator<DailyPeriod>
    {
        protected override IEnumerable<DailyPeriod> BuildModels(int count)
        {
            var roleFaker = new Faker<DailyPeriod>().Rules((f, r) =>
            {
                r.Name = f.Random.AlphaNumeric(5) + "QAName";
                r.StartMins = RandomGenerator.RandomIntBetween(300, 500);
                r.EndMins = RandomGenerator.RandomIntBetween(1000, 1500);
            });

            return roleFaker.Generate(count);
        }
    }
}