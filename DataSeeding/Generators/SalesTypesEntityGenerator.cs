using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    public class SalesTypesEntityGenerator : BaseGenerator<SalesType>
    {
        protected override IEnumerable<SalesType> BuildModels(int count)
        {
            var salesTypeFaker = new Faker<SalesType>().Rules((f, r) =>
            {
                r.Name = f.Random.AlphaNumeric(5) + "QAName";
                r.Colour = "green";
                r.ForecastItems = false;
                r.FlexBudgetFlexUp = 0;
                r.FlexBudgetFlexDown = 0;
                //r.Department = departmentId
            });

            return salesTypeFaker.Generate(count);
        }
    }
}
