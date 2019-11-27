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
   // [Binding]
    public class UserLevelsHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public UserLevelsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateUserLevel", Order = ScenarioStepsOrder.UserLevels)]
        public async Task CreateUserLevel()
        {
            var organisationId = Session.Get<Organisation>(Constants.Data.Organisation).ID;
            var userLevelEntity = new UserLevelEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
            });
            _lpHotelsMainUnitOfWork.UserLevel.Add(userLevelEntity);
            _lpHotelsMainUnitOfWork.SaveAsync();
            Session.Set(userLevelEntity, Constants.Data.UserLevel);
        }
    }
}