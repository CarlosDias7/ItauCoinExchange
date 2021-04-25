using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Repositories.Base.UnitsOfWork
{
    public interface IUnitOfWork
    {
        Task<TResult> ExecuteInTransactionScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<bool> condition, CancellationToken cancellationToken);
    }
}