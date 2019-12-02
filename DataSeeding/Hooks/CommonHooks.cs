using Common;
using DataSeeding.Framework;
using DataSeeding.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
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

        [AfterScenario(Order = ScenarioStepsOrder.DeleteAfterScenario)]
        public async Task DeleteData()
        {
            foreach (var model in Session.GetAll())
            {
                switch (model.GetType().Name)
                {
                    case nameof(Models.CreateShiftModel):
                        {
                            var notes = Session.Get<Models.CreateShiftModel>(Constants.Data.Shift).Notes;
                            var dbShift = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.Notes == notes).FirstOrDefault();
                            if (dbShift != null)
                            {
                                _lpHotelsMainUnitOfWork.TempShift.Remove(dbShift);
                            }
                        }
                        break;

                    case nameof(Location):
                        {
                            var locationToDelete = Session.Get<Location>(Constants.Data.Location);
                            if (locationToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.Location.Attach(locationToDelete);
                                _lpHotelsMainUnitOfWork.Location.Remove(locationToDelete);
                            };
                        }
                        break;

                    //case nameof(Organisation):
                    //    {
                    //        var organisationToDelete = Session.Get<Organisation>(Constants.Data.Organisation);
                    //        _lpHotelsMainUnitOfWork.Organisation.Attach(organisationToDelete);
                    //        _lpHotelsMainUnitOfWork.Organisation.Remove(organisationToDelete);
                    //    }
                    //    break;

                    //case nameof(User):
                    //    {
                    //        var userToDelete = Session.Get<User>(Constants.Data.User);
                    //        _lpHotelsMainUnitOfWork.User.Attach(userToDelete);
                    //        _lpHotelsMainUnitOfWork.User.Remove(userToDelete);
                    //    }
                    //    break;

                    //case nameof(UserLevel):
                    //    {
                    //        var userLevelToDelete = Session.Get<UserLevel>(Constants.Data.UserLevel);
                    //        _lpHotelsMainUnitOfWork.UserLevel.Attach(userLevelToDelete);
                    //        _lpHotelsMainUnitOfWork.UserLevel.Remove(userLevelToDelete);
                    //    }
                    //    break;

                    case nameof(TempShift):
                        {
                            var shiftsToDelete = Session.Get<TempShift>(Constants.Data.Shift);
                            _lpHotelsMainUnitOfWork.TempShift.Attach(shiftsToDelete);
                            _lpHotelsMainUnitOfWork.TempShift.Remove(shiftsToDelete);
                        }
                        break;

                    case nameof(TempArea):
                        {
                            var areaToDelete = Session.Get<TempArea>(Constants.Data.Area);
                            if (areaToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.TempArea.Attach(areaToDelete);
                                _lpHotelsMainUnitOfWork.TempArea.Remove(areaToDelete);
                            };

                            var areaAnotherOrganisationToDelete = Session.Get<TempArea>(Constants.Data.Area);
                            if (areaAnotherOrganisationToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.TempArea.Attach(areaAnotherOrganisationToDelete);
                                _lpHotelsMainUnitOfWork.TempArea.Remove(areaAnotherOrganisationToDelete);
                            };
                        }
                        break;

                    case nameof(StaffPayInfo):
                        {
                            var assignmenToDelete = Session.Get<StaffPayInfo>(Constants.Data.MainAssignment);
                            _lpHotelsMainUnitOfWork.StaffPayInfo.Attach(assignmenToDelete);
                            _lpHotelsMainUnitOfWork.StaffPayInfo.Remove(assignmenToDelete);
                        }
                        break;

                    case nameof(Department):
                        {
                            var departmentToDelete = Session.Get<Department>(Constants.Data.Department);
                            if (departmentToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.Department.Attach(departmentToDelete);
                                _lpHotelsMainUnitOfWork.Department.Remove(departmentToDelete);
                            };

                            //var departmentAnotherLocationSameOrganisationToDelete = Session.Get<Department>(Constants.Data.DepartmentAnotherLocationSameOrganisation);
                            //if (departmentAnotherLocationSameOrganisationToDelete != null)
                            //{
                            //    _lpHotelsMainUnitOfWork.Department.Attach(departmentAnotherLocationSameOrganisationToDelete);
                            //    _lpHotelsMainUnitOfWork.Department.Remove(departmentAnotherLocationSameOrganisationToDelete);
                            //};
                        }
                        break;

                    case nameof(TempStaff):
                        {
                            var employeeToDelete = Session.Get<TempStaff>(Constants.Data.Employee);
                            if (employeeToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.TempStaff.Attach(employeeToDelete);
                                _lpHotelsMainUnitOfWork.TempStaff.Remove(employeeToDelete);
                            };
                            //var employeeAnotherOrganisationToDelete = Session.Get<TempStaff>(Constants.Data.EmployeeAnotherOrganisation);
                            //if (employeeAnotherOrganisationToDelete != null)
                            //{
                            //    _lpHotelsMainUnitOfWork.TempStaff.Attach(employeeAnotherOrganisationToDelete);
                            //    _lpHotelsMainUnitOfWork.TempStaff.Remove(employeeAnotherOrganisationToDelete);
                            //}
                        }
                        break;

                    case nameof(JobTitle):
                        {
                            var jobTitleToDelete = Session.Get<JobTitle>(Constants.Data.JobTitle);
                            _lpHotelsMainUnitOfWork.JobTitle.Attach(jobTitleToDelete);
                            _lpHotelsMainUnitOfWork.JobTitle.Remove(jobTitleToDelete);
                        }
                        break;

                    case nameof(TempRole):
                        {
                            var roleToDelete = Session.Get<TempRole>(Constants.Data.Role);
                            if (roleToDelete != null)
                            {
                                _lpHotelsMainUnitOfWork.TempRole.Attach(roleToDelete);
                                _lpHotelsMainUnitOfWork.TempRole.Remove(roleToDelete);
                            };

                            //var roleAnotherOrganisationToDelete = Session.Get<TempRole>(Constants.Data.RoleAnoderOrganisation);
                            //if (roleAnotherOrganisationToDelete != null)
                            //{
                            //    _lpHotelsMainUnitOfWork.TempRole.Attach(roleAnotherOrganisationToDelete);
                            //    _lpHotelsMainUnitOfWork.TempRole.Remove(roleAnotherOrganisationToDelete);
                            //};
                        }
                        break;

                    default:
                        break;
                }
            }
            _lpHotelsMainUnitOfWork.SaveAsync();
        }
    }
}