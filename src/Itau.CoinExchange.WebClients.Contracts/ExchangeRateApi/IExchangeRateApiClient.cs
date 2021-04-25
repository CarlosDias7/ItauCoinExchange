using Itau.CoinExchange.WebClients.Contracts.Dtos.ExchangeRateApi;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.WebClients.Contracts.ExchangeRateApi
{
    [Obsolete("The API doesn't provide a endpoit of convertion for developers.")]
    public interface IExchangeRateApiClient
    {
        Task<ExchangeRateConvertCoinResultDto> ConvertCoinAsync(ExchangeRateConvertCoinDto dto, CancellationToken cancellationToken);
    }
}