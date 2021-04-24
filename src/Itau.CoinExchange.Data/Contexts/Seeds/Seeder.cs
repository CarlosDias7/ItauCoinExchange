using Itau.CoinExchange.Data.Contexts.Seeds.Segments;
using Microsoft.EntityFrameworkCore;

namespace Itau.CoinExchange.Data.Contexts.Seeds
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedSegments();
        }
    }
}