using FluentValidation;
using Itau.CoinExchange.Domain.Entities.Segments;
using MediatR;

namespace Itau.CoinExchange.Application.Queries.Segments.GetSegmentById
{
    public class GetSegmentByIdQuery : IRequest<Segment>
    {
        public long SegmentId { get; set; }

        public GetSegmentByIdQuery(long segmentId)
        {
            SegmentId = segmentId;
        }
    }

    public class GetSegmentByIdQueryValidator : AbstractValidator<GetSegmentByIdQuery>
    {
        public GetSegmentByIdQueryValidator()
        {
            RuleFor(x => x.SegmentId)
                .NotEmpty()
                .WithMessage(ApplicationMessages.GetSegmentByIdQuery_SegmentId_Is_Empty);
        }
    }
}