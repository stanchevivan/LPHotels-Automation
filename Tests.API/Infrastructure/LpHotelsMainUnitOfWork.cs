using System;
using Fourth.LabourProductivity.Scheduling.Domain.Models;
using TeamHours.DomainModel;
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

        //public IRepository<Location> Employees => throw new NotImplementedException();

        //IRepository<BankHoliday> ILpHotelsMainUnitOfWork.BankHoliday => throw new NotImplementedException();

        //IRepository<Location> ILpHotelsMainUnitOfWork.Employees => throw new NotImplementedException();

        public int Save()
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
