using Itau.CoinExchange.Data.Contexts;
using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Personnalites;
using Itau.CoinExchange.Domain.Entities.Segments.Privates;
using Itau.CoinExchange.Domain.Entities.Segments.Varejos;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Itau.CoinExchange.Api.Integration.Tests.Base
{
    public static class MockDbContextFactory
    {
        public static ItauCoinExchangeDbContext Create()
        {
            var mockDbContext = new Mock<ItauCoinExchangeDbContext>();

            mockDbContext.Setup(x => x.Segments)
                .Returns(GetMockSegments());

            return mockDbContext.Object;
        }

        private static DbSet<Segment> GetMockSegments()
        {
            var segments = new List<Segment>
            {
                new Personnalite(1, nameof(Personnalite), 0.45m),
                new Private(2, nameof(Private), 0.45m),
                new Varejo(3, nameof(Varejo), 0.45m)
            };

            IQueryable<Segment> queryableList = segments.AsQueryable();

            var mockSet = new Mock<DbSet<Segment>>();
            mockSet.As<IQueryable<Segment>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<Segment>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<Segment>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<Segment>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            return mockSet.Object;
        }
    }
}