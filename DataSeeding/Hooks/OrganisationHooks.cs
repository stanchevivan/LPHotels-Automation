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
        public static readonly string OrganisationSubdomain = ConfigurationManager.AppSettings["OrganisationSubdomain"];

        public OrganisationHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        //[Scope(Feature = "LocationsSteps")]
        [BeforeScenario("CreateOrganisation", Order = ScenarioStepsOrder.Organisation)]
        public async Task CreateOrganisation()
        {
            //var organisationEntity = _lpHotelsMainUnitOfWork.Organisation.GetAll().AsNoTracking().FirstOrDefault(x =>
            //    x.Subdomain == OrganisationSubdomain);

            //if (organisationEntity == null)
            //{
               var organisationEntity = new OrganisationEntityGenerator().GenerateSingle(x =>
                {
                    x.Subdomain = OrganisationSubdomain;
                    x.SystemName = "QaIntegration";
                    x.Name = "QAAutomation";
                    x.ForeignID = RandomGenerator.AlphaNumeric(12);
                    x.RotaApprovalNotificationUserLevelId = 1;
                    x.IncludeForecastSignoff = true;
                    x.DistributeAdditionalPayments = true;
                    x.FourthAccountId = RandomGenerator.AlphaNumeric(10);
                    x.PublishShiftsEnabled = true;
                    x.LabourDemandGraphEnabled = true;
                    x.EnableSalesForecasting = true;
                    x.DefaultDaySplitTime = TimeSpan.Parse("16:00:00.0000000");
                    x.DefaultDayPartName = "Day";
                    x.DefaultNightPartName = "Night";
                    x.CurrencyCulture = "en-GB";
                    x.HasDepartments = true;
                    x.ShiftTypesEnabled = true;
                });
            _lpHotelsMainUnitOfWork.Organisation.Add(organisationEntity);
                _lpHotelsMainUnitOfWork.SaveAsync();
                Session.Set(organisationEntity, Constants.Data.Organisation);

            //}

        }

        //[AfterScenario("CreateLocation", Order = 1)]
        //public async Task DeleteLocation()
        //{
        //    if (Session.Get<TempShift>(Constants.Data.Shift) != null)
        //    {
        //        var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
        //        var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
        //        _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
        //    }

        //    //if (Session.Get<TempShift>(Constants.Data.Shift) != null)
        //    //{
        //    //    var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
        //    //    var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
        //    //    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
        //    //}
        //    if (Session.Get<Location>(Constants.Data.Location) != null)
        //    {
        //        var locationToDelete = Session.Get<Location>(Constants.Data.Location);
        //        _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
        //        //  _lpHotelsMainUnitOfWork.SaveAsync();
        //    }
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}