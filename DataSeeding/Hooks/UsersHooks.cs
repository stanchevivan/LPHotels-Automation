using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace DataSeeding.Hooks
{
    //[Binding]
    public class UsersHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public UsersHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateUser", Order = ScenarioStepsOrder.User)]
        public async Task CreateUserAdmin()
        {
            var organisationId = Session.Get<Organisation>(Constants.Data.Organisation).ID;
            var userLevelId = Session.Get<UserLevel>(Constants.Data.UserLevel).ID;
            var userEntity = new UserEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.UserLevelID = userLevelId;
                x.Admin = true;
            });
            _lpHotelsMainUnitOfWork.User.Add(userEntity);
            _lpHotelsMainUnitOfWork.SaveAsync();
            Session.Set(userEntity, Constants.Data.User);
        }
    }
}