using Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi;
using Itau.CoinExchange.WebClients.CurrconvApi.Configurations;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Itau.CoinExchange.Utils.Objects;
using Itau.CoinExchange.WebClients.Contracts.CurrconvApi;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Itau.CoinExchange.WebClients.CurrconvApi
{
    public class CurrconvApiClient : ICurrconvApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly CurrconvApiOptions _options;

        public CurrconvApiClient(HttpClient httpClient, CurrconvApiOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<CurrconvConvertCoinResultDto> ConvertCoinAsync(CurrconvConvertCoinDto dto, CancellationToken cancellationToken)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"convert?apiKey={_options.ApiKey}&q={GetQueryParam(dto.CoinFrom, dto.CoinTo)}&date={dto.Date.ToString("yyyy-MM-dd")}");

            var response = await _httpClient.SendAsync(httpRequest, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(WebClientsMessages.CurrconvApiClient_Convertion_Is_Not_Possible);
            }

            var json = await response.Content.ReadAsStringAsync();
            return MapResult(dto, json);
        }

        private CurrconvConvertCoinResultDto MapResult(CurrconvConvertCoinDto dto, string jsonResponseMessage)
        {
            var data = JsonConvert.DeserializeObject<object>(jsonResponseMessage);
            if (data is null)
                throw new HttpRequestException(WebClientsMessages.CurrconvApiClient_Convertion_Is_Not_Possible);

            var results = data.GetProperty("results");
            var resultConvertion = results.GetProperty(GetQueryParam(dto.CoinFrom, dto.CoinTo));
            var valResultConverstion = resultConvertion.GetProperty("val");
            var currencyValue = valResultConverstion.GetProperty(dto.Date.ToString("yyyy-MM-dd"));

            if(!decimal.TryParse(currencyValue?.ToString(), out var currencyValueConverted))
                throw new HttpRequestException(WebClientsMessages.CurrconvApiClient_Convertion_Is_Not_Possible);

            return new CurrconvConvertCoinResultDto
            {
                CoinFrom = dto.CoinFrom,
                CoinTo = dto.CoinTo,
                CurrencyValue = currencyValueConverted
            };
        }

        private static string GetQueryParam(string coinFrom, string coinTo) => $"{coinFrom}_{coinTo}";
    }
}