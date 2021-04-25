using Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.WebClients.Contracts.CurrconvApi
{
    public interface ICurrconvApiClient
    {
        Task<CurrconvConvertCoinResultDto> ConvertCoinAsync(CurrconvConvertCoinDto dto, CancellationToken cancellationToken);
    }
}