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

        [Fact]
        public async Task ValidateSegmentController_Get_MustReturnsSuccessSegmentList()
        {
            var httpResponse = await _client.GetAsync("/api/v1/segments");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            Assert.Contains("Personnalite", stringResponse);
            Assert.Contains("Private", stringResponse);
            Assert.Contains("Varejo", stringResponse);
        }
    }
}
