using Itau.CoinExchange.Application.UseCases.CoinConvertion;
using Itau.CoinExchange.WebClients.Contracts.CurrconvApi;
using Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Queries.CoinConvertion.ConvertCoin
{
    public class ConvertCoinQueryHandler : IRequestHandler<ConvertCoinQuery, ConvertCoinResultDto>
    {
        private readonly ICurrconvApiClient _currconvApiClient;

        public ConvertCoinQueryHandler(ICurrconvApiClient currconvApiClient)
        {
            _currconvApiClient = currconvApiClient;
        }

        public async Task<ConvertCoinResultDto> Handle(ConvertCoinQuery request, CancellationToken cancellationToken)
        {
            var dto = new CurrconvConvertCoinDto(request.CoinFrom, request.CoinTo, request.Date);
            var resultDto = await _currconvApiClient.ConvertCoinAsync(dto, cancellationToken);
            var resultAmount = request.Amount * resultDto.CurrencyValue;

            return new ConvertCoinResultDto
            {
                Amount = request.Amount,
                Date = request.Date,
                CoinFrom = request.CoinFrom,
                ResultAmount = resultAmount,
                CoinTo = request.CoinTo
            };
        }
    }
}