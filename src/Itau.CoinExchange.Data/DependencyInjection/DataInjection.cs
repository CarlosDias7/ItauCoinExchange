using Itau.CoinExchange.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.Data.DependencyInjection
{
    public static class DataInjection
    {
        public static void UseDataContext(this IServiceCollection services)
        {
            services
                .AddScoped<DbContext, ItauCoinExchangeDbContext>()
                .AddDbContext<ItauCoinExchangeDbContext>();
        }
    }
}