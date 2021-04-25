using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Repositories.Base.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbDbContext)
        {
            _dbContext = dbDbContext;
        }

        public Task<TResult> ExecuteInTransactionScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<bool> condition, CancellationToken cancellationToken)
        {
            var executionStrategy = _dbContext.Database.CreateExecutionStrategy();
            return executionStrategy.ExecuteAsync(async () =>
            {
                var result = await operationAsync(cancellationToken);
                if (!condition()) return default(TResult);
                await SaveChangesAsync(cancellationToken);
                return result;
            });
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(false, cancellationToken) > 0;
    }
}