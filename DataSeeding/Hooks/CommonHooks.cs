using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataSeeding.Framework;
using DataSeeding.Infrastructure;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;

namespace DataSeeding.Hooks
{
    [Binding]
    public class CommonHooks
    {
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public CommonHooks(ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        //[Scope(Feature = "LocationsSteps")]
        //[BeforeScenario(Order = ScenarioStepsOrder.Location)]
        //public void LocationAreCreated()
        //{
        //    var location = new LocationEntityGenerator().GenerateSingle(x =>
        //    {
        //        x.Name = "LocationQaAutomation" + RandomGenerator.OnlyNumeric(4);
        //        x.OrganisationID = Constants.OgranisationId;
        //    });

        //    _lpHotelsMainUnitOfWork.Location.Add(location);
        //    _lpHotelsMainUnitOfWork.SaveAsync();

        //    Session.Set(location, Constants.Data.Location);
        //}

        [AfterScenario(Order = ScenarioStepsOrder.DeleteAfterScenario)]
        public async Task DeleteData()
        {
            foreach (var model in Session.GetAll())
            {
                switch (model.GetType().Name)
                {
                    //case nameof(Models.CreateShiftModel):
                    //    {
                    //        var notes = Session.Get<Models.CreateShiftModel>(Constants.Data.Shift).Notes;
                    //        var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
                    //        _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
                    //        break;
                    //    }
                    case nameof(Location):
                        {
                            var locationToDelete = Session.Get<Location>(Constants.Data.Location);
                            //_lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
                            locationToDelete.Deleted = true;
                            break;
                        }
                    default:
                        break;
                }

            }


            //if (Session.Get<Models.CreateShiftModel>(Constants.Data.Shift) != null)
            //{
            //    var notes = Session.Get<Models.CreateShiftModel>(Constants.Data.Shift).Notes;
            //    var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
            //    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            //}

            //if (Session.Get<TempShift>(Constants.Data.Shift) != null)
            //{
            //    var notes = Session.Get<TempShift>(Constants.Data.Shift).Notes;
            //    var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).First();
            //    _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
            //}

            //if (Session.Get<Location>(Constants.Data.Location) != null)
            //{
            //    var locationToDelete = Session.Get<Location>(Constants.Data.Location);
            //    _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
            //}

            //if (Session.Get<TempArea>(Constants.Data.Area) != null)
            //{
            //    var areaToDelete = Session.Get<TempArea>(Constants.Data.Area);
            //    _lpHotelsMainUnitOfWork.TempArea.Remove(areaToDelete);
            //}

            //if (Session.Get<StaffPayInfo>(Constants.Data.MainAssignment) != null)
            //{
            //    var assignmenToDelete = Session.Get<StaffPayInfo>(Constants.Data.MainAssignment);
            //    _lpHotelsMainUnitOfWork.StaffPayInfo.Remove(assignmenToDelete);
            //}

            //if (Session.Get<Department>(Constants.Data.Department) != null)
            //{
            //    var departmentToDelete = Session.Get<Department>(Constants.Data.Department);
            //    _lpHotelsMainUnitOfWork.Department.Remove(departmentToDelete);
            //}

            //if (Session.Get<TempStaff>(Constants.Data.Employee) != null)
            //{
            //    var employeeToDelete = Session.Get<TempStaff>(Constants.Data.Employee);
            //    _lpHotelsMainUnitOfWork.TempStaff.Remove(employeeToDelete);
            //}

            //if (Session.Get<JobTitle>(Constants.Data.JobTitle) != null)
            //{
            //    var jobTitleToDelete = Session.Get<JobTitle>(Constants.Data.JobTitle);
            //    _lpHotelsMainUnitOfWork.JobTitle.Remove(jobTitleToDelete);
            //}

            //if (Session.Get<TempRole>(Constants.Data.Role) != null)
            //{
            //    var roleToDelete = Session.Get<TempRole>(Constants.Data.Role);
            //    _lpHotelsMainUnitOfWork.TempRole.Remove(roleToDelete);
            //}

            _lpHotelsMainUnitOfWork.SaveAsync();
        }
    }
}