using System;
using System.Collections.Generic;
using System.Configuration;
using Fourth.TestTools.Generators;
using TeamHours.DomainModel;
using Bogus;
using Common;

namespace DataSeeding.Generators
{
    public class UserEntityGenerator :BaseGenerator<User>
    {
        protected override IEnumerable<User> BuildModels(int count)
        {
            var userFaker = new Faker<User>().Rules((f, u) =>
            {
                u.EmailAddress = RandomGenerator.OnlyNumeric(10) + "@" + RandomGenerator.OnlyNumeric(5) + ".com";
                u.Surname = "QaAutomationUserSurname";
                u.Forename = "QaAutomationUserForename";
                u.EncryptedPassword = RandomGenerator.OnlyNumeric(15);
            });
            return userFaker.Generate(count);
        }
    }
}
