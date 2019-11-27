using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TechTalk.SpecFlow;
using TeamHours.DomainModel;

namespace DataSeeding.Hooks
{
    [Binding]
    public class AreasHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public AreasHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateArea", Order = ScenarioStepsOrder.Area)]
        public void AreaIsCreated()
        {
            var organisationId = Constants.OgranisationId;
            var area = new AreaEntityGenerator().GenerateSingle( x =>
            {
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.TempArea.Add(area);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(area, Constants.Data.Area);
        }

        [BeforeScenario("CreateAreaAnotherOrganisation", Order = ScenarioStepsOrder.Area)]
        public void AreaAnotherOrganisationIsCreated()
        {
            var organisationId = Constants.AnotherOgranisationId;
            var area = new AreaEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.TempArea.Add(area);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(area, Constants.Data.AreaAnotherOrganisation);
        }
    }
}
