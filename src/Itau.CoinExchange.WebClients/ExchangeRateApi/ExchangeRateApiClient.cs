using Itau.CoinExchange.WebClients.Contracts.Dtos.ExchangeRateApi;
using Itau.CoinExchange.WebClients.Contracts.ExchangeRateApi;
using Itau.CoinExchange.WebClients.ExchangeRateApi.Configurations;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.WebClients.ExchangeRateApi
{
    [Obsolete("The API doesn't provide a endpoit of convertion for developers.")]
    public class ExchangeRateApiClient : IExchangeRateApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ExchangeRateApiOptions _options;

        public ExchangeRateApiClient(HttpClient httpClient, ExchangeRateApiOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<ExchangeRateConvertCoinResultDto> ConvertCoinAsync(ExchangeRateConvertCoinDto dto, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, "convert");
            httpRequest.Headers.Add("access_key", _options.AccessKey);
            httpRequest.Headers.Add("from", dto.CoinFrom);
            httpRequest.Headers.Add("to", dto.CoinTo);
            httpRequest.Headers.Add("amount", dto.Amount.ToString());

            var date = dto.Date == DateTime.MinValue ? DateTime.Today.ToShortTimeString() : dto.Date.ToShortDateString();
            httpRequest.Headers.Add("date", date);

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                var jsonError = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ExchangeRateConvertCoinErrorDto>(jsonError);
                throw new HttpRequestException(string.Format(WebClientsMessages.ExchangeRateApiClient_Convert_Is_Not_Possible, error.Error.Message));
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExchangeRateConvertCoinResultDto>(json);
        }
    }
}