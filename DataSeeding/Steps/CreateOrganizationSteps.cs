using System.Configuration;
using System.Data.Entity;
using System.Linq;
using TechTalk.SpecFlow;
using Tests.API.Infrastructure;
using Tests.API.Generators;
using Common;
using Tests.API.Framework;
using System.Threading.Tasks;

namespace DataSeeding.DataSetupSteps
{
    [Binding]
    public class CreateOrganizationSteps
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsUnitOfWork;

        public static readonly string OrganisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];

        public CreateOrganizationSteps(ILpHotelsMainUnitOfWork lpHotelsUnitOfWork)
        {
            _lpHotelsUnitOfWork = lpHotelsUnitOfWork;

        }

        [Scope(Feature = "LocationsSteps")]
        [BeforeScenario("Organisation", Order = 1)]
        public async Task CreateOrganisation()
        {
            var organisationEntity = _lpHotelsUnitOfWork.Organisation.GetAll().AsNoTracking().FirstOrDefault(x =>
                x.Subdomain == OrganisationSubdomain);

            if (organisationEntity == null)
            {
                organisationEntity = new OrganisationEntityGenerator().GenerateSingle(x =>
                {
                    x.Subdomain = OrganisationSubdomain;
                });
                _lpHotelsUnitOfWork.Organisation.Add(organisationEntity);
                _lpHotelsUnitOfWork.SaveAsync();
                Session.Set(organisationEntity, Constants.Data.Organisation);

            }

        }

        //[Scope(Feature = "LocationsSteps")]
        //[AfterScenario("Organisation", Order = 1)]
        //public async Task DeleteOrganisation()
        //{
        //        var organisationToDelete = Session.Get<TeamHours.DomainModel.Organisation>(Constants.Data.Organisation);
        //        _lpHotelsUnitOfWork.Organisation.Remove(organisationToDelete);
        //        _lpHotelsUnitOfWork.SaveAsync();
        //}



        //[Scope(Feature = "LocationsSteps")]
        [AfterScenario("Organisation", Order = 1)]
        public async Task DeleteOrganisation()
        {
            var organisationToDelete = Session.Get<TeamHours.DomainModel.Organisation>(Constants.Data.Organisation);
            _lpHotelsUnitOfWork.Organisation.Remove(organisationToDelete);
            _lpHotelsUnitOfWork.SaveAsync();
        }

        [BeforeScenario("CreateLocation", Order = 1)]
        public void LocationAreCreated()
        {
            System.Console.WriteLine("HELLO !! ! ! ! !");
            var organisationId = 1;//Session.Get<OrganisationEntity>(Constants.Data.Organization);

            var location = new LocationEntityGenerator().GenerateSingle( x =>
            {
                x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
                x.OrganisationID = organisationId;
            });

            _lpHotelsUnitOfWork.Location.Add(location);
            _lpHotelsUnitOfWork.SaveAsync();

              Session.Set(location, Constants.Data.Location);

        }

        [AfterScenario("CreateLocation", Order = 1)]
        public async Task DeleteLocation()
        {
            var locationToDelete = Session.Get<TeamHours.DomainModel.Location>(Constants.Data.Location);
            _lpHotelsUnitOfWork.Location.Remove(locationToDelete);
            _lpHotelsUnitOfWork.SaveAsync();
        }
    }
}
