using Itau.CoinExchange.Application.DependencyInjection;
using Itau.CoinExchange.Data.DependencyInjection;
using Itau.CoinExchange.Repositories.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.DependenciesInjections
{
    public static class DependencyInjectionManager
    {
        public static void UseItauExchangeDependencies(this IServiceCollection services)
        {
            services.UseApplication();
            services.UseRepositories();
            services.UseDataContext();
        }
    }
}