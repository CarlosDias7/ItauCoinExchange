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
        }
    }
}