using System;
using Fourth.LabourProductivity.Scheduling.Domain.Models;

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

        public IRepository<Employee> Employees => _repositoryFactory.GetRepository<Employee>();

        public IRepository<Employee> CustomerJobTitles => throw new NotImplementedException();

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
