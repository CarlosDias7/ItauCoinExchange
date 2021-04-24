using Itau.CoinExchange.Domain.Base.Entities;

namespace Itau.CoinExchange.Domain.Entities.Segments
{
    public abstract class Segment : Entity<long>
    {
        public const int NameMaxLength = 30;

        public string Name { get; private set; }
        public decimal ExchangeRate { get; private set; }

        public Segment(string name, decimal exchangeRate)
        {
            Name = name;
            ExchangeRate = exchangeRate;
        }

        public void SetExchangeRate(decimal exChangeRate)
        {
            if(exChangeRate < decimal.Zero)
            {
                AddError(DomainMessages.Segment_ExchangeRate_Less_Than_Zero);
                return;
            }

            ExchangeRate = exChangeRate;
        }

        private void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                AddError(DomainMessages.Segment_Name_Is_Empty);
                return;
            }

            if(name.Length > NameMaxLength)
            {
                AddError(string.Format(DomainMessages.Segment_Name_Max_Length_Exceeded, NameMaxLength));
                return;
            }

            Name = name;
        }
    }
}