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
    public class ActualSalesEntityGenerator : BaseGenerator<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL>
    {
        protected override IEnumerable<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL> BuildModels(int count)
        {
            var actualSalesFaker = new Faker<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL>().Rules((f, a) =>
            {
                //departmentId
                //salesTypeId
                a.SalesDate = DateTime.UtcNow.AddMonths(-2);
                a.StartHour = 5;
                a.StartMins = 0;
                a.Sales = 3;
                a.Items = 1;
                
            });

            return actualSalesFaker.Generate(count);
        }
    }
}
