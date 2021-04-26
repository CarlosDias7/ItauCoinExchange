using Itau.CoinExchange.Domain.Entities.Segments;
using Itau.CoinExchange.Domain.Entities.Segments.Personnalites;
using Itau.CoinExchange.Domain.Entities.Segments.Privates;
using Itau.CoinExchange.Domain.Entities.Segments.Varejos;
using System;

namespace Itau.CoinExchange.Domain.Tests.Entities.Segments.Factories
{
    public class SegmentFactory<TEntity>
        where TEntity : Segment
    {
        public Segment Create(string name, decimal exchangeRate)
        {
            if (typeof(TEntity) == typeof(Personnalite))
                return new Personnalite(new Random().Next(), name, exchangeRate);

            if (typeof(TEntity) == typeof(Private))
                return new Private(new Random().Next(), name, exchangeRate);

            if (typeof(TEntity) == typeof(Varejo))
                return new Varejo(new Random().Next(), name, exchangeRate);

            throw new ArgumentException("O tipo do segmento informado não está definido.");
        }
    }
}