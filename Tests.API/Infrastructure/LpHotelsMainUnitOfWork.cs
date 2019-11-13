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

        public IRepository<Organisation> Orgasization => _repositoryFactory.GetRepository<Organisation>();

        public IRepository<Organisation> Organisation => throw new NotImplementedException();

        public IRepository<Department> Department => _repositoryFactory.GetRepository<Department>();

        public IRepository<TempStaff> TempStaff => _repositoryFactory.GetRepository<TempStaff>();

        public IRepository<TempArea> TempArea => _repositoryFactory.GetRepository<TempArea>();

        //public IRepository<Location> Employees => throw new NotImplementedException();

        //IRepository<BankHoliday> ILpHotelsMainUnitOfWork.BankHoliday => throw new NotImplementedException();

        //IRepository<Location> ILpHotelsMainUnitOfWork.Employees => throw new NotImplementedException();

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
