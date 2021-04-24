namespace Itau.CoinExchange.Domain.Entities.Segments.Varejos
{
    public class Varejo : Segment
    {
        public Varejo(string name, decimal exchangeRate)
            : base(name, exchangeRate)
        {
        }

        protected override bool Validate()
            => OnValidate(this, new VarejoValidator());
    }
}