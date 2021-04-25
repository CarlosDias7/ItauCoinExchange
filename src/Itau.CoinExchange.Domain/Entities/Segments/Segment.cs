using Itau.CoinExchange.Domain.Base.Entities;
using System;

namespace Itau.CoinExchange.Domain.Entities.Segments
{
    public abstract class Segment : Entity<long>
    {
        public const int NameMaxLength = 30;

        public string Name { get; private set; }
        public decimal ExchangeRate { get; private set; }

        protected Segment(string name, decimal exchangeRate)
        {
            Name = name;
            ExchangeRate = exchangeRate;
        }

        public virtual void SetExchangeRate(decimal exChangeRate)
        {
            if(exChangeRate < decimal.Zero)
            {
                AddError(DomainMessages.Segment_ExchangeRate_Less_Than_Zero);
                return;
            }

            ExchangeRate = exChangeRate;
        }

        public virtual decimal ApplyExchangeRate(decimal amount)
        { 
            if(amount < decimal.Zero)
                throw new ArgumentOutOfRangeException(DomainMessages.Segment_ApplyExchangeRate_Amount_Less_Than_Zero);

            return Math.Round(amount * (1m + ExchangeRate), 2);
        }
    }
}