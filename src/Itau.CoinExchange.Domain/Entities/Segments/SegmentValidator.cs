using FluentValidation;

namespace Itau.CoinExchange.Domain.Entities.Segments
{
    public abstract class SegmentValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : Segment
    {
        public SegmentValidator()
        {
            RuleFor(x => x.ExchangeRate)
                .GreaterThanOrEqualTo(decimal.Zero)
                .WithMessage(DomainMessages.Segment_ExchangeRate_Less_Than_Zero);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(DomainMessages.Segment_Name_Is_Empty)
                .MaximumLength(Segment.NameMaxLength)
                .WithMessage(string.Format(DomainMessages.Segment_Name_Max_Length_Exceeded, Segment.NameMaxLength));
        }
    }
}