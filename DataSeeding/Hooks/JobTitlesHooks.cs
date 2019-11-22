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
    public class JobTitlesHooks
    {

        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public JobTitlesHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [BeforeScenario("CreateJobTitle", Order = ScenarioStepsOrder.JobTitle)]
        public void JobTitleIsCreated()
        {
            var roleId = Session.Get<TempRole>(Constants.Data.Role).ID;
            var jobTitle = new JobTitleEntityGenerator().GenerateSingle(x =>
            {
                x.OrganisationID = Constants.OgranisationId;
                x.TempRoleID = roleId;
            });

            _lpHotelsMainUnitOfWork.JobTitle.Add(jobTitle);
            _lpHotelsMainUnitOfWork.SaveAsync();

            Session.Set(jobTitle, Constants.Data.JobTitle, true);
        }

        //[AfterScenario("CreateJobTitle", Order = ScenarioStepsOrder.JobTitle)]
        //public async Task DeleteJobTitle()
        //{
        //    var jobTitleToDelete = Session.Get<JobTitle>(Constants.Data.JobTitle);
        //    _lpHotelsMainUnitOfWork.JobTitle.Remove(jobTitleToDelete);
        //    _lpHotelsMainUnitOfWork.SaveAsync();
        //}
    }
}
