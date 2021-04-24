using Itau.CoinExchange.Domain.Base.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Repository.Base
{
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(TId id);

        void Delete(TEntity entity);

        Task DeleteAsync(TId id, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        bool Any(TId id);

        Task<bool> AnyAsync(TId id, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);

        TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}