using Itau.CoinExchange.Application.Commands.Segments.UpdateSegment;
using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.Notifications.Contexts;
using Itau.CoinExchange.Application.Contracts.UseCases;
using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Itau.CoinExchange.Application.Notifications.Contexts;
using Itau.CoinExchange.Application.Queries.Segments.GetSegmentById;
using Itau.CoinExchange.Repositories.Base.UnitsOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.UseCases.Segments
{
    public class UpdateSegmentExchangeRateUseCase : TransactedUseCase, IUpdateSegmentExchangeRateUseCase
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;

        public UpdateSegmentExchangeRateUseCase(IMediator mediator, INotificationContext notificationContext, IUnitOfWork unitOfWork)
            :base(unitOfWork, notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        public async Task<SegmentDto> ExecuteAsync(long segmentId, decimal exchangeRate, CancellationToken cancellationToken) 
            => await ExecuteInTransactionScopeAsync
            (
                operationAsync: token => OnExecutingAsync(segmentId, exchangeRate, cancellationToken), 
                cancellationToken
            );

        private async Task<SegmentDto> OnExecutingAsync(long segmentId, decimal exchangeRate, CancellationToken cancellationToken)
        {
            try
            {
                var segment = await _mediator.Send(new GetSegmentByIdQuery(segmentId), cancellationToken);
                if (segment is null)
                {
                    _notificationContext.AddNotification(ApplicationMessages.UpdateSegmentExchangeRateUseCase_Segmento_Not_Found);
                    return null;
                }

                segment.SetExchangeRate(exchangeRate);
                if (!segment.Valid)
                {
                    _notificationContext.AddNotifications(segment.ValidationResult);
                    return null;
                }

                await _mediator.Send(new UpdateSegmentCommand(segment), cancellationToken);
                if (_notificationContext.HasNotifications)
                    return null;

                return new SegmentDto
                {
                    Id = segment.Id,
                    Name = segment.Name,
                    ExchangeRate = segment.ExchangeRate
                };
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification(ex);
            }

            return null;
        }
    }
}