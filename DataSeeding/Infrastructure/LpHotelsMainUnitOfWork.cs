using System;
using TeamHours.DomainModel;
using Fourth.LabourProductivity.Scheduling.Domain.Scheduling.Models;

namespace DataSeeding.Infrastructure
{
    public class LpHotelsMainUnitOfWork : ILpHotelsMainUnitOfWork
    {
        private readonly RepositoryFactory _repositoryFactory;
        private readonly LpHotelsDbContext _lpHotelsMainDataContext;

        public LpHotelsMainUnitOfWork(LpHotelsDbContext lpHotelsMainDataContext)
        {
            _lpHotelsMainDataContext = lpHotelsMainDataContext;
            _repositoryFactory = new RepositoryFactory(lpHotelsMainDataContext);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<Location> Location => _repositoryFactory.GetRepository<Location>();

        public IRepository<BankHoliday> BankHoliday => _repositoryFactory.GetRepository<BankHoliday>();

        public IRepository<Organisation> Organisation => _repositoryFactory.GetRepository<Organisation>();

        public IRepository<Department> Department => _repositoryFactory.GetRepository<Department>();

        public IRepository<TempStaff> TempStaff => _repositoryFactory.GetRepository<TempStaff>();

        public IRepository<TempArea> TempArea => _repositoryFactory.GetRepository<TempArea>();

        public IRepository<TempRole> TempRole => _repositoryFactory.GetRepository<TempRole>();

        public IRepository<JobTitle> JobTitle => _repositoryFactory.GetRepository<JobTitle>();

        public IRepository<StaffPayInfo> StaffPayInfo => _repositoryFactory.GetRepository<StaffPayInfo>();

        public IRepository<TempShift> TempShift => _repositoryFactory.GetRepository<TempShift>();

        public IRepository<DailyPeriod> DailyPeriod => _repositoryFactory.GetRepository<DailyPeriod>();

        public IRepository<User> User => _repositoryFactory.GetRepository<User>();

        public IRepository<UserLevel> UserLevel => _repositoryFactory.GetRepository<UserLevel>();

        public IRepository<AdditionalRole> AdditionalRole => _repositoryFactory.GetRepository<AdditionalRole>();

        public IRepository<ScheduleDto> ScheduleDto => _repositoryFactory.GetRepository<ScheduleDto>();

        public IRepository<ScheduleDto> LabourDemandDto => throw new NotImplementedException();

        public IRepository<SalesType> SalesType => _repositoryFactory.GetRepository<SalesType>();

        public IRepository<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL> ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL => _repositoryFactory.GetRepository<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL>();

        public IRepository<WorkloadRules> WorkloadRules => _repositoryFactory.GetRepository<WorkloadRules>();

        public int SaveAsync()
        {
            return _lpHotelsMainDataContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _lpHotelsMainDataContext?.Dispose();
            }
        }
    }
}
