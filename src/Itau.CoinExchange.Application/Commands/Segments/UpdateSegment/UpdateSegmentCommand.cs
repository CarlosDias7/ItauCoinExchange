using FluentValidation;
using Itau.CoinExchange.Domain.Entities.Segments;
using MediatR;

namespace Itau.CoinExchange.Application.Commands.Segments.UpdateSegment
{
    public class UpdateSegmentCommand : IRequest<bool>
    {
        public Segment Segment { get; set; }

        public UpdateSegmentCommand(Segment segment)
        {
            Segment = segment;
        }
    }

    public class UpdateSegmentCommandValidator : AbstractValidator<UpdateSegmentCommand>
    {
        public UpdateSegmentCommandValidator()
        {
            RuleFor(x => x.Segment)
                .NotEmpty()
                .WithMessage(ApplicationMessages.UpdateSegmentExchageRateCommand_Segment_Is_Empty);

            RuleFor(x => x.Segment.Id)
                .NotEmpty()
                .When(x => x.Segment is not null)
                .WithMessage(ApplicationMessages.UpdateSegmentExchageRateCommand_Segment_Id_Is_Empty);
        }
    }
}