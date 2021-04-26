namespace Itau.CoinExchange.Application.Contracts.Dtos.Segments
{
    public class ConvertCoinBySegmentDto
    {
        public string CoinFrom { get; set; }
        public decimal Amount { get; set; }
        public long SegmentId { get; set; }
    }
}