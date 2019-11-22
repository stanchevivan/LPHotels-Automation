using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataSeeding.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly LpHotelsDbContext _database;

        public Repository(LpHotelsDbContext database)
        {
            _database = database;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return (IQueryable<TEntity>)this._database.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _database.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _database.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _database.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _database.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _database.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _database.Dispose();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
