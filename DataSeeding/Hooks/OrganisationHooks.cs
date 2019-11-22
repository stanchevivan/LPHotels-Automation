using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using TechTalk.SpecFlow;
using TeamHours.DomainModel;

namespace DataSeeding.Hooks
{
   // [Binding]
    public class OrganisationHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;
        //private readonly LocationFacade _locationFacade;
        //private readonly string _customerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];
        public static readonly string OrganisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];

        public OrganisationHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
            // _locationFacade = locationFacade;
        }

        [Scope(Feature = "LocationsSteps")]
        [BeforeScenario("Organisation", Order = 1)]
        public async Task CreateOrganisation()
        {
            var organisationEntity = _lpHotelsMainUnitOfWork.Organisation.GetAll().AsNoTracking().FirstOrDefault(x =>
                x.Subdomain == OrganisationSubdomain);

            if (organisationEntity == null)
            {
                organisationEntity = new OrganisationEntityGenerator().GenerateSingle(x =>
                {
                    x.Subdomain = OrganisationSubdomain;
                    x.SystemName = "integration";
                });
                _lpHotelsMainUnitOfWork.Organisation.Add(organisationEntity);
                _lpHotelsMainUnitOfWork.SaveAsync();
                Session.Set(organisationEntity, Constants.Data.Organisation);

            }

        }

        [AfterScenario("CreateLocation", Order = 1)]
        public async Task DeleteLocation()
        {
            if (Session.Get<TempShift>(Constants.Data.Shift) != null)
            {
                var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
                var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
                _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            }

            //if (Session.Get<TempShift>(Constants.Data.Shift) != null)
            //{
            //    var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
            //    var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
            //    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            //}
            if (Session.Get<Location>(Constants.Data.Location) != null)
            {
                var locationToDelete = Session.Get<Location>(Constants.Data.Location);
                _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
                //  _lpHotelsMainUnitOfWork.SaveAsync();
            }
            _lpHotelsMainUnitOfWork.SaveAsync();
        }
    }
}