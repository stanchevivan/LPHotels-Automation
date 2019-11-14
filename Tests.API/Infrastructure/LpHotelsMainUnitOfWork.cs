using System;
using TeamHours.DomainModel;

namespace Tests.API.Infrastructure
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
