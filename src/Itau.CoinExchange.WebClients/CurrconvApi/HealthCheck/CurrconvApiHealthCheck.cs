using Itau.CoinExchange.WebClients.Contracts.CurrconvApi;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.WebClients.CurrconvApi.HealthCheck
{
    public class CurrconvApiHealthCheck : IHealthCheck
    {
        private readonly ICurrconvApiClient _currconvApiClient;

        public CurrconvApiHealthCheck(ICurrconvApiClient currconvApiClient)
        {
            _currconvApiClient = currconvApiClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _currconvApiClient.HealthCheckAsync(cancellationToken);
                return result
                    ? HealthCheckResult.Healthy(WebClientsMessages.CurrconvApiHealthCheck_Healthy)
                    : HealthCheckResult.Unhealthy(WebClientsMessages.CurrconvApiHealthCheck_UnHealthy);
            }
            catch
            {
                return HealthCheckResult.Unhealthy(WebClientsMessages.CurrconvApiHealthCheck_UnHealthy);
            }
        }
    }
}