using System;
using System.Collections.Generic;
using Bogus;
using Common;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;

namespace DataSeeding.Generators
{
    public class NonMainAssignmentEntityGenerator : BaseGenerator<AdditionalRole>
    {
        protected override IEnumerable<AdditionalRole> BuildModels(int count)
        {
            var mainAssignmentFaker = new Faker<AdditionalRole>().Rules((f, a) =>
            {
                //a.TempStaffID = employeeId;
                a.FromDate = DateTime.UtcNow.AddYears(-1);
                //a.DepartmentID = from department;
                a.RateOverride = RandomGenerator.RandomIntBetween(1, 5);
                //a.RoleID = from role
                //a.JobTitleID = from jobTitles
            });
            return mainAssignmentFaker.Generate(count);
        }
    }
}