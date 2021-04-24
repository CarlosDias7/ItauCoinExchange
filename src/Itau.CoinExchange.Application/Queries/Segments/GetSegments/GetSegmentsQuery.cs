using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using MediatR;
using System.Collections.Generic;

namespace Itau.CoinExchange.Application.Queries.Segments.GetSegments
{
    public class GetSegmentsQuery : IRequest<IEnumerable<SegmentDto>>
    {
    }
}