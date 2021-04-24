using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Contracts.UseCases.Segments
{
    public interface IGetSegmentsUseCase
    {
        Task<IEnumerable<SegmentDto>> ExecuteAsync(CancellationToken cancellationToken);
    }
}