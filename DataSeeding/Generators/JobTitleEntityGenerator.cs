using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;
namespace DataSeeding.Generators
{
    public class JobTitleEntityGenerator : BaseGenerator<JobTitle>
    {
        protected override IEnumerable<JobTitle> BuildModels(int count)
        {
            var jobTitleFaker = new Faker<JobTitle>().Rules((f, j) =>
            {
                j.Name = f.Name.Random.AlphaNumeric(5) + "QADepName";
                j.ForeignID = RandomGenerator.OnlyLetters(2).ToUpper() + "_" + RandomGenerator.RandomIntBetween(10000, 20000);
                //j.TempRoleID = from Role
            });

            return jobTitleFaker.Generate(count);
        }
    }
}
