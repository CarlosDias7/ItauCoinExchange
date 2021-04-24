using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Personnalites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Itau.CoinExchange.Data.Configurations.Segments
{
    public class PersonnaliteConfiguration : IEntityTypeConfiguration<Personnalite>
    {
        public void Configure(EntityTypeBuilder<Personnalite> builder)
        {
            builder
                .HasBaseType<Segment>();
        }
    }
}