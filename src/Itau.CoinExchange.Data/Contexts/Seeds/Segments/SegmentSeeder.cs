using Itau.CoinExchange.Domain.Entities.Segments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Itau.CoinExchange.Data.Contexts.Seeds.Segments
{
    public static class SegmentSeeder
    {
        public static void SeedSegments(this ModelBuilder modelBuilder)
        {
            var types = Assembly.GetAssembly(typeof(Segment))?.GetTypes()
                .Where(type => type.IsClass && type.IsAbstract is false && type.IsSubclassOf(typeof(Segment)));

            foreach (var type in types)
            {
                var data = new
                {
                    Id = (long)new Random().Next(),
                    Name = type.Name,
                    ExchangeRate = decimal.Zero
                };

                modelBuilder
                    .Entity(type)
                    .HasData(data);
            }
        }
    }
}