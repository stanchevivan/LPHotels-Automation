using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Common;
using DataSeeding.Framework;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    class UserLevelEntityGenerator : BaseGenerator<UserLevel>
    {
        protected override IEnumerable<UserLevel> BuildModels(int count)
        {
            var organisationId = Session.Get<Organisation>(Constants.Data.Organisation).ID;
            var userLevelFaker = new Faker<UserLevel>().Rules((f, u) =>
            {
                u.Name = "QALevel";
                u.ForeignID = RandomGenerator.AlphaNumeric(7);
            });
            return userLevelFaker.Generate(count);
        }
    }
}