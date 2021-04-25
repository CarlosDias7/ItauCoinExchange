using Itau.CoinExchange.Application.DependencyInjection;
using Itau.CoinExchange.Data.DependencyInjection;
using Itau.CoinExchange.Repositories.DependencyInjection;
using Itau.CoinExchange.WebClients.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.DependenciesInjections
{
    public static class DependencyInjectionManager
    {
        public static void UseItauExchangeDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseApplication();
            services.UseRepositories();
            services.UseDataContext();
            services.UseWebClients(configuration);
        }
    }
}