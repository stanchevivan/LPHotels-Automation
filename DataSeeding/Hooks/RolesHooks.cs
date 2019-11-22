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
            var areaId = Session.Get<TempRole>(Constants.Data.Area).ID;
            var role = new RoleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = Constants.OgranisationId;
                x.TempAreaID = areaId;
            });

            _lpHotelsMainUnitOfWork.TempRole.Add(role);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(role, Constants.Data.Role);
        }

        //[AfterScenario("CreateRole", Order = ScenarioStepsOrder.Role)]
        //public async Task DeleteRole()
        //{
        //    var roleToDelete = Session.Get<TempRole>(Constants.Data.Role);
        //    _lpHotelsMainUnitOfWork.TempRole.Remove(roleToDelete);
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}
