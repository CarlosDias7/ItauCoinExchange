using FluentValidation;
using Itau.CoinExchange.Application.UseCases.CoinConvertion;
using MediatR;
using System;

namespace Itau.CoinExchange.Application.Queries.CoinConvertion.ConvertCoin
{
    public class ConvertCoinQuery : IRequest<ConvertCoinResultDto>
    {
        public string CoinFrom { get; set; }
        public string CoinTo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public ConvertCoinQuery(string coinFrom, string coinTo, decimal amount, DateTime date)
        {
            CoinFrom = coinFrom;
            CoinTo = coinTo;
            Amount = amount;
            Date = date;
        }
    }

    public class ConvertCoinBySegmentCommandValidator : AbstractValidator<ConvertCoinQuery>
    {
        public ConvertCoinBySegmentCommandValidator()
        {
            RuleFor(x => x.CoinFrom)
                .NotEmpty()
                .WithMessage(ApplicationMessages.ConvertCoinBySegmentCommand_CoinFrom_Is_Empty);

            RuleFor(x => x.CoinTo)
                .NotEmpty()
                .WithMessage(ApplicationMessages.ConvertCoinBySegmentCommand_CoinTo_Is_Empty);

            RuleFor(x => x.Amount)
                .GreaterThan(decimal.Zero)
                .WithMessage(ApplicationMessages.ConvertCoinBySegmentCommand_Amoun_Less_Than_Zero);

            RuleFor(x => x.Date)
                .NotEmpty()
                .WithMessage(ApplicationMessages.ConvertCoinBySegmentCommand_Date_Is_Invalid);
        }
    }
}