using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeeding.Infrastructure
{
    public class RepositoryFactory
    {
        private readonly LpHotelsDbContext _context;

        private readonly IDictionary<Type, object> _cachedRepositories = new Dictionary<Type, object>();

        public RepositoryFactory(LpHotelsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var modelType = typeof(TEntity);

            if (!_cachedRepositories.ContainsKey(modelType))
            {
                _cachedRepositories.Add(modelType, new Repository<TEntity>(_context));
            }

            return (IRepository<TEntity>)_cachedRepositories[modelType];
        }
    }
}

