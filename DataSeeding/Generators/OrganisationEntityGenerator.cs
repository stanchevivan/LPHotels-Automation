using System.Collections.Generic;
using System.Configuration;
using Bogus;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    public class OrganisationEntityGenerator : BaseGenerator<Organisation> 
    {
        private readonly string _organisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];

        protected override IEnumerable<Organisation> BuildModels(int count)
        {
            var organisationEntityFaker = new Faker<Organisation>().Rules((f, x) =>
                {
                    x.Name = "name";
                }
        );
            return organisationEntityFaker.Generate(count);
        }
    }
}
