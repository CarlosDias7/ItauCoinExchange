using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Application.Contracts.Notifications.Contexts;
using Itau.CoinExchange.Application.Contracts.UseCases.Segments;
using Itau.CoinExchange.Application.Queries.CoinConvertion.ConvertCoin;
using Itau.CoinExchange.Application.Queries.Segments.GetSegmentById;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.UseCases.Segments
{
    public class ConvertCoinBySegmentUseCase : IConvertCoinBySegmentUseCase
    {
        private readonly IMediator _mediator;
        private readonly INotificationContext _notificationContext;

        public ConvertCoinBySegmentUseCase(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        public async Task<ConvertCoinBySegmentResultDto> ExecuteAsync(ConvertCoinBySegmentDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var convertionResult = await _mediator.Send(new ConvertCoinQuery(dto.CoinFrom, dto.CoinTo, dto.Amount, DateTime.Today), cancellationToken);
                if (convertionResult is null)
                {
                    _notificationContext.AddNotification(ApplicationMessages.ConvertCoinBySegmentUseCase_Coin_Convertion_Is_Not_Possible);
                    return null;
                }

                var segment = await _mediator.Send(new GetSegmentByIdQuery(dto.SegmentId), cancellationToken);
                if (segment is null)
                {
                    _notificationContext.AddNotification(ApplicationMessages.ConvertCoinBySegmentUseCase_Segment_Not_Found);
                    return null;
                }

                var convertedAmount = segment.ApplyExchangeRate(convertionResult.ResultAmount);
                return new ConvertCoinBySegmentResultDto
                {
                    Amount = convertionResult.Amount,
                    CoinFrom = convertionResult.CoinFrom,
                    CoinTo = convertionResult.CoinTo,
                    ConvertedAmount = convertedAmount,
                    SegmentId = segment.Id,
                    SegmentName = segment.Name
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