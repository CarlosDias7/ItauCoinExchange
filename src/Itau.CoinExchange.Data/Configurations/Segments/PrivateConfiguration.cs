using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Privates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.CoinExchange.Data.Configurations.Segments
{
    public class PrivateConfiguration : IEntityTypeConfiguration<Private>
    {
        public void Configure(EntityTypeBuilder<Private> builder)
        {
            builder
                .HasBaseType<Segment>();
        }
    }
}