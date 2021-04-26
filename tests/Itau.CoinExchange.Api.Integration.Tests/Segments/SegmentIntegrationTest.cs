using Itau.CoinExchange.Api.Integration.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Itau.CoinExchange.Api.Integration.Tests.Segments
{
    public class SegmentIntegrationTest : IClassFixture<ItauCoinExchangeWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public SegmentIntegrationTest(ItauCoinExchangeWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }
    }
}
