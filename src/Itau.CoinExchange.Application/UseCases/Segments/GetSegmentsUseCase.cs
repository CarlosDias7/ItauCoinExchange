using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.Notifications.Contexts;
using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Itau.CoinExchange.Application.Queries.Segments.GetSegments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.UseCases.Segments
{
    public class GetSegmentsUseCase : IGetSegmentsUseCase
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;

        public GetSegmentsUseCase(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        public Task<IEnumerable<SegmentDto>> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                return _mediator.Send(new GetSegmentsQuery());
            }
            catch (Exception ex)
            {
                _notificationContext.AddNotification(ex);
            }

            return Task.FromResult<IEnumerable<SegmentDto>>(null);
        }
    }
}