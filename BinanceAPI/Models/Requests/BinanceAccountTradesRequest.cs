namespace BinanceAPI.Models
{
    public class BinanceAccountTradesRequest : BinanceRequest
    {
        public string Symbol { get; set; }

        public int? Limit { get; set; }

        public int? FromId { get; set; }

        internal override string BuildRequestString() =>
            $"symbol={this.Symbol}" +           
            $"{TryGetRequestParameter(this.Limit, "limit")}" +
            $"{TryGetRequestParameter(this.FromId, "fromId")}" +
            $"&{base.BuildRequestString()}";
    }
}