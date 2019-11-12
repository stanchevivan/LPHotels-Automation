using System;
using System.Linq;
using Common;
using TechTalk.SpecFlow;
using Tests.API.Framework;
using Tests.API.Generators;
using Tests.API.Infrastructure;

namespace Tests.API.Features_and_Steps.Steps
{
    [Binding]
    public class LocationsSteps
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;
        //private readonly LocationFacade _locationFacade;
        //private readonly string _customerCanonicalId = ConfigurationManager.AppSettings["CustomerCanonicalId"];

        public LocationsSteps(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
            // _locationFacade = locationFacade;
        }

        [Given(@"(.*) locations are created and saved into database")]
        public void LocationsAreCreated(int count)
        {
            //var organisation = Session.Get<OrganisationEntity>(Constants.Data.Organization);
            var organisation = 123;

            var locations = new LocationEntityGenerator().GenerateMultiple(count, x =>
            {
                x.Name = "ShouldBeReturned" + RandomGenerator.OnlyNumeric(2);
            }).ToList();

            locations.ForEach(x => x.OrganisationID = 1);
             _lpHotelsMainUnitOfWork.Location.AddRange(locations);
             _lpHotelsMainUnitOfWork.Save();

            if (count == 1)
            {
                Session.Set(locations.First(), Constants.Data.Location, true);
            }
            else
            {
                Session.Set(locations, Constants.Data.Locations, true);
            }
        }

        [Given(@"bank are created and saved into database")]
        public void BankHolidaysAreCreated()
        {
            //var organisation = Session.Get<OrganisationEntity>(Constants.Data.Organization);
            //var location = 1313;

            var bank = new BankHolidayEntityGenerator().GenerateSingle();
            try
            {
                _lpHotelsMainUnitOfWork.BankHoliday.Add(bank);
                _lpHotelsMainUnitOfWork.Save();
            }
            catch(Exception e)
            {

            }

            

                Session.Set(bank, Constants.Data.Location);

        }
    }
}