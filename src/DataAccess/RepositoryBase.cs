using Microsoft.EntityFrameworkCore;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Extentions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Stockpot.DataAccess
{
    public abstract class RepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly StockpotDbContext _dbContext;

        public RepositoryBase(DbContextProvider dbContextProvider)
        {
            _dbContext = dbContextProvider.DbContext;
        }

        internal StockpotDbContext DbContext => _dbContext;

        protected virtual IQueryable<TEntity> GetDbSet()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity[]> Get(bool track = false)
        {
            var entities = await GetDbSet()
                .SetTracking(track)
                .ToArrayAsync();

            return entities;
        }

        public async Task<TEntity> GetSingle(TKey id, bool track = false)
        {
            if (id == null)
            {
                new ArgumentNullException(nameof(id));
            }

            var entity = await GetDbSet()
				.Where(e => e.Id.Equals(id))
                .SetTracking(track)
				.SingleAsync();

            return entity;
        }

        public async Task<TEntity> GetSingleOrDefault(TKey id, bool track = false)
        {
            if (id == null)
            {
                new ArgumentNullException(nameof(id));
            }

            var entity = await GetDbSet()
                .Where(e => e.Id.Equals(id))
                .SetTracking(track)
                .SingleOrDefaultAsync();

            return entity;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                new ArgumentNullException(nameof(entity));
            }

            _dbContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                new ArgumentNullException(nameof(entity));
            }

            _dbContext.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                new ArgumentNullException(nameof(entity));
            }

            _dbContext.Remove(entity);
        }

        public async Task Delete(TKey id)
        {
            if (id == null)
            {
                new ArgumentNullException(nameof(id));
            }

            var entity = await GetSingleOrDefault(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }
    }
}
