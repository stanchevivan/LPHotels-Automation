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
            var area = new AreaEntityGenerator().GenerateSingle( x =>
            {
                x.OrganisationID = Constants.OgranisationId;
            });

            _lpHotelsMainUnitOfWork.TempArea.Add(area);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(area, Constants.Data.Area, true);
        }

        //[AfterScenario("CreateArea", Order = ScenarioStepsOrder.Area)]
        //public async Task DeleteArea()
        //{
        //    var areaToDelete = Session.Get<TempArea>(Constants.Data.Area);
        //    _lpHotelsMainUnitOfWork.TempArea.Remove(areaToDelete);
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}
