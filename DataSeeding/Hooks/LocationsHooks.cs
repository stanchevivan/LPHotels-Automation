using System;
using System.Linq;
using System.Threading.Tasks;
using Common;
using TechTalk.SpecFlow;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;

namespace DataSeeding
{
    [Binding]
    public class LocationsHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;


        public LocationsHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        //[Scope(Feature = "LocationsSteps")]
        [BeforeScenario("CreateLocation", Order = ScenarioStepsOrder.Location)]
        public void LocationAreCreated()
        {
            var location = new LocationEntityGenerator().GenerateSingle(x =>
            {
                x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = Constants.OgranisationId;
            });

            _lpHotelsMainUnitOfWork.Location.Add(location);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(location, Constants.Data.Location);
        }

        [AfterScenario("CreateLocation", Order = ScenarioStepsOrder.Location)]
        public async Task DeleteLocation()
        {
            if (Session.Get<Models.CreateShiftModel>(Constants.Data.Shift) != null)
            {
                var notes = Session.Get<Models.CreateShiftModel>(Constants.Data.Shift).Notes;
                var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).FirstOrDefault();
                if (dbShift != null)
                {
                    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);

                }
            }

            //if (Session.Get<TempShift>(Constants.Data.Shift) != null)
            //{
            //    var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
            //    var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
            //    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            //}

            //    if (Session.Get<Location>(Constants.Data.Location) != null)
            //    {
            //        var locationToDelete = Session.Get<Location>(Constants.Data.Location);
            //        _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
            //    }

            //    _lpHotelsMainUnitOfWork.SaveAsync();
        }

        //[AfterScenario("CreateLocation", Order = 1)]
        //public async Task DeleteLocation()
        //{
        //    var locationToDelete = Session.Get<TeamHours.DomainModel.Location>(Constants.Data.Location);
        //    _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}