namespace Itau.CoinExchange.Domain.Entities.Segments.Varejos
{
    public class Varejo : Segment
    {
        public Varejo(long id, string name, decimal exchangeRate)
            : base(id, name, exchangeRate)
        {
            Validate();
        }

        protected override bool Validate()
            => OnValidate(this, new VarejoValidator());
    }
}