using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;

namespace DataSeeding.Generators
{
    public class AreaEntityGenerator : BaseGenerator<TempArea>
    {
        protected override IEnumerable<TempArea> BuildModels(int count)
        {
            var areaFakerEmtity = new Faker<TempArea>().Rules((f, a) =>
            {
                a.Name = f.Name.Random.AlphaNumeric(5) + "QaAutomation";               
            });

            return areaFakerEmtity.Generate(count);
        }
    }
}
