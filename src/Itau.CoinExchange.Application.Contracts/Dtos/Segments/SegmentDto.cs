namespace Itau.CoinExchange.Application.Contracts.Dtos.Segments
{
    public class SegmentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}