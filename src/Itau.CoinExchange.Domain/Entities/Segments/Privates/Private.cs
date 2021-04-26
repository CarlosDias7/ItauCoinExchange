namespace Itau.CoinExchange.Domain.Entities.Segments.Privates
{
    public class Private : Segment
    {
        public Private(long id, string name, decimal exchangeRate)
            : base(id, name, exchangeRate)
        {
            Validate();
        }

        protected override bool Validate()
            => OnValidate(this, new PrivateValidator());
    }
}