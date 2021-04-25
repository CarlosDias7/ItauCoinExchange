using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Contracts.UseCases.Segments
{
    public interface IConvertCoinBySegmentUseCase
    {
        Task<ConvertCoinBySegmentResultDto> ExecuteAsync(ConvertCoinBySegmentDto dto, CancellationToken cancellationToken);
    }
}