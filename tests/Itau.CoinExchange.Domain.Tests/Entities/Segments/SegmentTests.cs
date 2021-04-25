using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Tests.Entities.Segments.Factories;
using System;
using Xunit;

namespace Itau.CoinExchange.Domain.Tests.Entities.Segments
{
    public abstract class SegmentTests<TEntity>
        where TEntity : Segment
    {
        private readonly SegmentFactory<TEntity> _segmentFactory;

        public SegmentTests()
        {
            _segmentFactory = new SegmentFactory<TEntity>();
        }

        [Theory(DisplayName = "Create the segment.")]
        [InlineData("Private", 0)]
        [InlineData("Segmento Private", 1.0)]
        [InlineData("Itaú - Segmento Private", 99.0)]
        [InlineData("Itaú - Segmento Varejo", 0.02)]
        [InlineData("Segmento Personalitte", 51.79)]
        protected void BuildAPrivateSegment_MustBeCreated_MustBeValid(string name, decimal exchangeRate)
        {
            // Arrange
            var entity = _segmentFactory.Create(name, exchangeRate);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(name, entity.Name);
            Assert.Equal(exchangeRate, entity.ExchangeRate);
            Assert.True(entity.Valid);
        }

        [Theory(DisplayName = "Create the segment with an invalid name")]
        [InlineData("")]
        [InlineData("1234567890123456789012345678901234567890")]
        protected void BuildAPrivateSegmentWithAnInvalidName_MustBeCreated_MustBeInvalid(string name)
        {
            // Arrange
            var entity = _segmentFactory.Create(name, 1.5m);

            // Assert
            Assert.NotNull(entity);
            Assert.False(entity.Valid);
        }

        [Theory(DisplayName = "Change the ExchangeRate property to an invalid value.")]
        [InlineData(-10.5)]
        [InlineData(-1)]
        [InlineData(-999.99)]
        protected void ChangeExchageRateToValueLessThanZero_MustBeInvalid_CannotBeChanged(decimal invalidExchangeRate)
        {
            // Arrange
            var entity = _segmentFactory.Create(nameof(TEntity), decimal.Zero);

            // Act
            entity.SetExchangeRate(invalidExchangeRate);

            // Assert
            Assert.False(entity.Valid);
            Assert.NotEqual(invalidExchangeRate, entity.ExchangeRate);
        }

        [Theory(DisplayName = "Apply exnchage rate of the segment to an defined amount.")]
        [InlineData(0, 1.0, 1.0)]
        [InlineData(1.0, 1.0, 2.0)]
        [InlineData(0.45, 55.10, 79.90)]
        protected void ApplyExchangeRateToManyAmounts_MustBeTheExpectedResult(decimal exchagenRate, decimal amount, decimal expectedResult)
        {
            // Arrange
            var entity = _segmentFactory.Create(nameof(TEntity), exchagenRate);

            // Act
            var result = entity.ApplyExchangeRate(amount);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact(DisplayName = "ApplyExchangeRateToAnAmountLessThanZero_AExceptionMustBeThrowed exchange rate of the segment to a amount less than zero.")]
        protected void ApplyExchangeRateToAnAmountLessThanZero_AExceptionMustBeThrowed()
        {
            // Arrange
            var entity = _segmentFactory.Create(nameof(TEntity), decimal.Zero);
            var amount = -0.01m;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => entity.ApplyExchangeRate(amount));
        }
    }
}