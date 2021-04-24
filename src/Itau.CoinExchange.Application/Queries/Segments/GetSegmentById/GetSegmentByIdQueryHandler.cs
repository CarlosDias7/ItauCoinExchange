using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Queries.Segments.GetSegmentById
{
    public class GetSegmentByIdQueryHandler : IRequestHandler<GetSegmentByIdQuery, Segment>
    {
        private readonly ISegmentRepository _segmentRepository;

        public GetSegmentByIdQueryHandler(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public async Task<Segment> Handle(GetSegmentByIdQuery request, CancellationToken cancellationToken)
            => await _segmentRepository.GetByIdAsync(request.SegmentId, cancellationToken);
    }
}