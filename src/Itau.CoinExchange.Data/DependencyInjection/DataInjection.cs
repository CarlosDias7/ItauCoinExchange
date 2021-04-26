using Itau.CoinExchange.Data.Contexts;
using Itau.CoinExchange.Data.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.Data.DependencyInjection
{
    public static class DataInjection
    {
        public static void UseDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            var itauCoinExchageSqlServerOptions = new ItauCoinExchageSqlServerOptions();
            configuration.GetSection(nameof(ItauCoinExchageSqlServerOptions)).Bind(itauCoinExchageSqlServerOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(itauCoinExchageSqlServerOptions);

            services
                .AddScoped<DbContext, ItauCoinExchangeDbContext>()
                .AddDbContext<ItauCoinExchangeDbContext>();
        }
    }
}