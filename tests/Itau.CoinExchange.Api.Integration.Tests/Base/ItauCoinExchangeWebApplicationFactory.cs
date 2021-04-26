using Itau.CoinExchange.Data.Contexts;
using Itau.CoinExchange.WebClients.ExchangeRateApi.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.Api.Integration.Tests.Base
{
    public class ItauCoinExchangeWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Staging");
            builder.ConfigureServices(services =>
            {
                var mockDbContext = MockDbContextFactory.Create();
                services.AddScoped<DbContext, ItauCoinExchangeDbContext>(serv => mockDbContext);

                var exchangeRateApiOptions = new ExchangeRateApiOptions
                {
                    // TO DO
                };
            });
        }
    }
}