using Itau.CoinExchange.Application.Contracts.Notifications.Contexts;
using Itau.CoinExchange.Repositories.Base.UnitsOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Contracts.UseCases
{
    public abstract class TransactedUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public TransactedUseCase(IUnitOfWork unitOfWork, INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public Task<TResult> ExecuteInTransactionScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, CancellationToken cancellationToken)
            => _unitOfWork.ExecuteInTransactionScopeAsync(operationAsync, () => !_notificationContext.HasNotifications, cancellationToken);
    }
}