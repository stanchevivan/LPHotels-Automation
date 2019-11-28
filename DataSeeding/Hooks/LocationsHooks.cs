using System.Threading.Tasks;
using Common;
using TechTalk.SpecFlow;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;
using System.Linq;

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

        [BeforeScenario("CreateLocation", Order = ScenarioStepsOrder.Location)]
        public void LocationAreCreated()
        {
            var organisationId = Constants.OgranisationId;
            var location = new LocationEntityGenerator().GenerateSingle(x =>
            {
                x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.Location.Add(location);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(location, Constants.Data.Location);
        }

        [BeforeScenario("CreateLocations", Order = ScenarioStepsOrder.Location)]
        public void LocationsAreCreated()
        {
            var organisationId = Constants.OgranisationId;
            var locations = new LocationEntityGenerator().GenerateMultiple(3,x =>
            {
                x.Name = "LocationsQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = organisationId;
            }).ToList();

            _lpHotelsMainUnitOfWork.Location.AddRange(locations);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(locations, Constants.Data.Locations);
        }

        [BeforeScenario("LocationForAnotherOrganisation", Order = ScenarioStepsOrder.Location)]
        public void LocationAnotherOrganisationIsCreated()
        {
            var organisationId = Constants.AnotherOgranisationId;
            var location = new LocationEntityGenerator().GenerateSingle(x =>
            {
                x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = organisationId;
            });

            _lpHotelsMainUnitOfWork.Location.Add(location);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(location, Constants.Data.LocationAnotherOrganisation);
        }
    }
}