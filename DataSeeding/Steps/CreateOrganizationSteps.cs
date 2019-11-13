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
    }
}
