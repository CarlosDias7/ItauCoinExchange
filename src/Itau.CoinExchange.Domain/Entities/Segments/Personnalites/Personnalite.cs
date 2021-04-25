﻿namespace Itau.CoinExchange.Domain.Entities.Segments.Personnalites
{
    public class Personnalite : Segment
    {
        public Personnalite(string name, decimal exchangeRate)
            : base(name, exchangeRate)
        {
            Validate();
        }

        protected override bool Validate()
            => OnValidate(this, new PersonnaliteValidator());
    }
}