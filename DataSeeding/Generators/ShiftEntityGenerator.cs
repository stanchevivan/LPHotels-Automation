﻿using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace DataSeeding.Generators
{
    public class ShiftEntityGenerator : BaseGenerator<TempShift>
    {
        protected override IEnumerable<TempShift> BuildModels(int count)
        {
            var shiftFaker = new Faker<TempShift>().Rules((f, s) =>
            {
                //s.DepartmentID = from dep
                //s.TempStaffID = from employee
                //s.TempRoleID = from role
                s.ChargedDate = DateTime.UtcNow.AddDays(2);
                s.StartDateTime = DateTime.UtcNow.AddDays(RandomGenerator.RandomIntBetween(10,300));
                s.EndDateTime = s.StartDateTime.AddHours(2);
                s.Break1DurationInMinutes = RandomGenerator.RandomIntBetween(1, 10);
                s.Break2DurationInMinutes = RandomGenerator.RandomIntBetween(1, 10);
                s.Notes = f.Random.AlphaNumeric(5) + "QANotes";
                s.Actual = true;
                s.ShiftTypeID = 0;
            });

            return shiftFaker.Generate(count);
        }
    }
}
