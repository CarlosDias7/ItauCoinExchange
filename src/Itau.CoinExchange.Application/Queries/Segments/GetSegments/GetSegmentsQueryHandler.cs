using Itau.CoinExchange.Application.Contracts.Dtos.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Queries.Segments.GetSegments
{
    public class GetSegmentsQueryHandler : IRequestHandler<GetSegmentsQuery, IEnumerable<SegmentDto>>
    {
        private readonly ISegmentRepository _segmentRepository;

        public GetSegmentsQueryHandler(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public async Task<IEnumerable<SegmentDto>> Handle(GetSegmentsQuery request, CancellationToken cancellationToken)
        {
            var segments = await _segmentRepository.GetAsync(cancellationToken);
            return segments
                ?.Select(segment => new SegmentDto
                {
                    Id = segment.Id,
                    Name = segment.Name,
                    ExchangeRate = segment.ExchangeRate
                })
                .ToList();
        }
    }
}