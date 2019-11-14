using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace Tests.API.Generators
{
    public class RoleEntityGenerator : BaseGenerator<TempRole>
    {
        protected override IEnumerable<TempRole> BuildModels(int count)
        {
            var roleFaker = new Faker<TempRole>().Rules((f, r) =>
            {
                r.Name = f.Random.AlphaNumeric(5) + "QAName";
                //r.TempAreaID = from area
                r.Symbol = f.Random.AlphaNumeric(2).ToUpper();
            });

            return roleFaker.Generate(count);
        }
    }
}
