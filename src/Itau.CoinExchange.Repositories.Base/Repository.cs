using Itau.CoinExchange.Domain.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Repository.Base
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(DbContext dbDbContext)
        {
            _dbSet = dbDbContext.Set<TEntity>();
        }

        public virtual void Delete(TId id)
        {
            var entity = GetById(id, asTracking: true);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null) return;
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken, asTracking: true);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return;
            await Task.Run(() => Delete(entity), cancellationToken);
        }

        public virtual bool Any(TId id)
            => _dbSet.Any(x => Equals(x.Id, id));

        public virtual Task<bool> AnyAsync(TId id, CancellationToken cancellationToken)
            => _dbSet.AnyAsync(x => Equals(x.Id, id), cancellationToken);

        public virtual TEntity Add(TEntity entity)
        {
            if (entity is null) return default;
            if (Any(entity.Id)) return entity;
            var entityEntry = _dbSet.Add(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is null) return default;
            if (await AnyAsync(entity.Id, cancellationToken)) return entity;
            var entityEntry = await _dbSet.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
            => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

        public TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return _dbSet.Find(id);

            return include is null
                ? _dbSet.AsNoTracking().SingleOrDefault(x => Equals(x.Id, id))
                : include(_dbSet).AsNoTracking().SingleOrDefault(x => Equals(x.Id, id));
        }

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return await _dbSet.FindAsync(new object[] { id }, cancellationToken);

            return include is null
                ? await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => Equals(x.Id, id), cancellationToken)
                : await include(_dbSet).AsNoTracking().SingleOrDefaultAsync(x => Equals(x.Id, id), cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            if (Any(entity.Id) is false) return;
            _dbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await AnyAsync(entity.Id, cancellationToken) is false) return;
            _dbSet.Update(entity);
        }
    }
}