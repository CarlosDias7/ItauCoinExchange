namespace Itau.CoinExchange.Domain.Entities.Segments.Personnalites
{
    public class Personnalite : Segment
    {
        public Personnalite(long id, string name, decimal exchangeRate)
            : base(id, name, exchangeRate)
        {
            Validate();
        }

        protected override bool Validate()
            => OnValidate(this, new PersonnaliteValidator());
    }
}