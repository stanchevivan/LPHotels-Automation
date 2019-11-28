using System;
using System.Collections.Generic;
using System.Linq;
using TeamHours.DomainModel;

namespace DataSeeding.Infrastructure
{
    public interface IRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
    }
}
