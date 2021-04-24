using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Varejos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.CoinExchange.Data.Configurations.Segments
{
    public class VarejoConfiguration : IEntityTypeConfiguration<Varejo>
    {
        public void Configure(EntityTypeBuilder<Varejo> builder)
        {
            builder
                .HasBaseType<Segment>();
        }
    }
}