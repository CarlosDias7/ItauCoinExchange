using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Personnalites;
using Itau.CoinExchange.Domain.Entities.Segments.Privates;
using Itau.CoinExchange.Domain.Entities.Segments.Varejos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.CoinExchange.Data.Configurations.Segments
{
    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(Segment.NameMaxLength)
                .IsRequired();

            builder
                .Property(x => x.ExchangeRate)
                .HasPrecision(10, 2)
                .IsRequired();

            builder
                .Ignore(x => x.ValidationResult);

            builder
                .HasDiscriminator(EntityConfigurationConstants.DiscriminatorDefault, typeof(string))
                .HasValue<Personnalite>(nameof(Personnalite))
                .HasValue<Private>(nameof(Private))
                .HasValue<Varejo>(nameof(Varejo));
        }
    }
}