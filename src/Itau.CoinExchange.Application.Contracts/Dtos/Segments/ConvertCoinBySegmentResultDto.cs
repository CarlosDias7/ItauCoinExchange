namespace Itau.CoinExchange.Application.Contracts.Dtos.Segments
{
    public class ConvertCoinBySegmentResultDto
    {
        public long SegmentId { get; set; }
        public string SegmentName { get; set; }
        public string CoinFrom { get; set; }
        public decimal Amount { get; set; }
        public string CoinTo { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}