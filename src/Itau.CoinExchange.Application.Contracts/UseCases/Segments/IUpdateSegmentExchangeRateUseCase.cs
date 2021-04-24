using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Contracts.UseCases.Segments
{
    public interface IUpdateSegmentExchangeRateUseCase
    {
        Task<SegmentDto> ExecuteAsync(long segmentId, decimal exchangeRate, CancellationToken cancellationToken);
    }
}