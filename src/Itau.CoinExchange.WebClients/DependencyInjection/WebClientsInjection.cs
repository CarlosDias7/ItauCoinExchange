using Itau.CoinExchange.WebClients.Contracts.CurrconvApi;
using Itau.CoinExchange.WebClients.Contracts.ExchangeRateApi;
using Itau.CoinExchange.WebClients.CurrconvApi;
using Itau.CoinExchange.WebClients.CurrconvApi.Configurations;
using Itau.CoinExchange.WebClients.CurrconvApi.HealthCheck;
using Itau.CoinExchange.WebClients.ExchangeRateApi;
using Itau.CoinExchange.WebClients.ExchangeRateApi.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Itau.CoinExchange.WebClients.DependencyInjection
{
    public static class WebClientsInjection
    {
        public static void UseWebClients(this IServiceCollection services, IConfiguration configuration)
        {
            var exchangeRateOptions = new ExchangeRateApiOptions();
            configuration.GetSection(nameof(ExchangeRateApiOptions)).Bind(exchangeRateOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(exchangeRateOptions);

            services.AddHttpClient<IExchangeRateApiClient, ExchangeRateApiClient>(c =>
            {
                c.BaseAddress = new Uri(exchangeRateOptions.BaseAddress);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddPolicyHandler(GetRetryPolicy(exchangeRateOptions.RetryCount, exchangeRateOptions.SleepDurationInSeconds))
            .AddPolicyHandler(GetCircuitBreakerPolicy(exchangeRateOptions.HandledEventsAllowedBeforeBreaking, exchangeRateOptions.DurationOfBreakInSeconds));

            var currconvOptions = new CurrconvApiOptions();
            configuration.GetSection(nameof(CurrconvApiOptions)).Bind(currconvOptions, c => c.BindNonPublicProperties = true);
            services.AddSingleton(currconvOptions);

            services.AddHttpClient<ICurrconvApiClient, CurrconvApiClient>(c =>
            {
                c.BaseAddress = new Uri(currconvOptions.BaseAddress);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddPolicyHandler(GetRetryPolicy(currconvOptions.RetryCount, currconvOptions.SleepDurationInSeconds))
            .AddPolicyHandler(GetCircuitBreakerPolicy(currconvOptions.HandledEventsAllowedBeforeBreaking, currconvOptions.DurationOfBreakInSeconds));

            services.AddHealthChecks()
                .AddCheck<CurrconvApiHealthCheck>(nameof(CurrconvApiHealthCheck), Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount, int sleepDurationInSeconds) 
            => HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(sleepDurationInSeconds));

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(int handledEventsAllowedBeforeBreaking, int durationOfBreakInSeconds) 
            => HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(durationOfBreakInSeconds));
    }
}