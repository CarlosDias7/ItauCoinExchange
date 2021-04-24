using Itau.CoinExchange.Domain.Entities.Segments.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.CoinExchange.Repositories.DependencyInjection
{
    public static class RepositoryInjection
    {
        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISegmentRepository, SegmentRepository>();
        }
    }
}