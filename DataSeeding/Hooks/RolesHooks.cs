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
        private readonly ScenarioContext context;

        public RolesHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork, ScenarioContext context)
        {
            this.context = context;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateRole", Order = ScenarioStepsOrder.Role)]
        public void RoleIsCreated()
        {
            var organisationId = Constants.OgranisationId;
            var areaId = context.Get<TempArea>(Constants.Data.Area).ID;
            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.TempAreaID = areaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(role, Constants.Data.Role);
        }

        [BeforeScenario("CreateRoleForAnotherOrganisation", Order = ScenarioStepsOrder.Role)]
        public void RoleForAnotherOrganisationIsCreated()
        {
            var organisationId = Constants.AnotherOgranisationId;
            var areaId = context.Get<TempArea>(Constants.Data.AreaAnotherOrganisation).ID;
            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
                x.TempAreaID = areaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(role, Constants.Data.RoleAnoderOrganisation);
        }
    }
}
