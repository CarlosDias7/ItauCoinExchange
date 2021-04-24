using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Repositories;
using Itau.CoinExchange.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Itau.CoinExchange.Repositories
{
    public class SegmentRepository : Repository<Segment, long>, ISegmentRepository
    {
        public SegmentRepository(DbContext dbDbContext)
            : base(dbDbContext)
        {
        }
    }
}