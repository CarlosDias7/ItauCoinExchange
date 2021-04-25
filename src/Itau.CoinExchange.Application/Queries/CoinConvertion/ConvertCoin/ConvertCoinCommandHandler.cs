using Itau.CoinExchange.Application.UseCases.CoinConvertion;
using Itau.CoinExchange.WebClients.Contracts.CurrconvApi;
using Itau.CoinExchange.WebClients.Contracts.Dtos.CurrconvApi;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Application.Queries.CoinConvertion.ConvertCoin
{
    public class ConvertCoinCommandHandler : IRequestHandler<ConvertCoinCommand, ConvertCoinResultDto>
    {
        private readonly ICurrconvApiClient _currconvApiClient;

        public ConvertCoinCommandHandler(ICurrconvApiClient currconvApiClient)
        {
            _currconvApiClient = currconvApiClient;
        }

        public async Task<ConvertCoinResultDto> Handle(ConvertCoinCommand request, CancellationToken cancellationToken)
        {
            var dto = new CurrconvConvertCoinDto(request.CoinFrom, request.CoinTo, request.Date);
            var resultDto = await _currconvApiClient.ConvertCoinAsync(dto, cancellationToken);
            var resultAmount = Math.Round(request.Amount * resultDto.CurrencyValue, 2);

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