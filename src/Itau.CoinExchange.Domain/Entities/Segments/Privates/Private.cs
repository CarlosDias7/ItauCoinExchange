namespace Itau.CoinExchange.Domain.Entities.Segments.Privates
{
    public class Private : Segment
    {
        public Private(string name, decimal exchangeRate)
            : base(name, exchangeRate)
        {
            Validate();
        }

        protected override bool Validate()
            => OnValidate(this, new PrivateValidator());
    }
}