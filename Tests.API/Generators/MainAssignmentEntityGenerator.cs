using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace Tests.API.Generators
{
    class MainAssignmentEntityGenerator : BaseGenerator<StaffPayInfo>
    {
        protected override IEnumerable<StaffPayInfo> BuildModels(int count)
        {
            var mainAssignmentFaker = new Faker<StaffPayInfo>().Rules((f, a) =>
            {
                //a.TempStaffID = employeeId from tempStaff ;
                a.FromDate = DateTime.UtcNow;
                //a.HomeDepartmentID = from department;
                a.Rate = RandomGenerator.RandomIntBetween(1, 5);
                //a.PrimaryRoleID = from role
                //a.JobTitleID = from jobTitles
                a.ContractedDays = RandomGenerator.RandomIntBetween(3, 5);
                a.ContractedHours = RandomGenerator.RandomIntBetween(3, 5);
                a.RatePer = f.PickRandom<StaffPayType>();
            });

            return mainAssignmentFaker.Generate(count);
        }
    }
}