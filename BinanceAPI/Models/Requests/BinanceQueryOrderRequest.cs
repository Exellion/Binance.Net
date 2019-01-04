namespace BinanceAPI.Models
{
    public class BinanceQueryOrderRequest : BinanceRequest
    {
        public string Symbol { get; set; }

        public long? OrderId { get; set; }

        public string OriginClientOrderId { get; set; }

        internal override string BuildRequestString() => 
            $"symbol={this.Symbol}" +
            $"{TryGetRequestParameter(this.OrderId, "orderId")}" +
            $"{TryGetRequestParameter(this.OriginClientOrderId, "origClientOrderId")}" +
            $"&{base.BuildRequestString()}";
    }
}