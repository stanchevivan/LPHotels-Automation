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
    [Binding]
    public class RolesHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public RolesHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateRole", Order = ScenarioStepsOrder.Role)]
        public void RoleIsCreated()
        {
            var organisationId = Constants.OgranisationId;
            var areaId = Session.Get<TempArea>(Constants.Data.Area).ID;
            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.TempAreaID = areaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(role, Constants.Data.Role);
        }

        [BeforeScenario("CreateRoleForAnotherOrganisation", Order = ScenarioStepsOrder.Role)]
        public void RoleForAnotherOrganisationIsCreated()
        {
            var organisationId = Constants.AnotherOgranisationId;
            var areaId = Session.Get<TempArea>(Constants.Data.AreaAnotherOrganisation).ID;
            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.TempAreaID = areaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(role, Constants.Data.RoleAnoderOrganisation);
        }
    }
}
