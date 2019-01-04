namespace BinanceAPI.Models
{
    public class BinanceAllOrdersRequest : BinanceOpenOrdersRequest
    {
        public long? OrderId { get; set; }

        public int? Limit { get; set; }

        internal override string BuildRequestString() =>
            $"{base.BuildRequestString()}" +
            $"{TryGetRequestParameter(this.OrderId, "orderId")}" +
            $"{TryGetRequestParameter(this.Limit, "limit")}";
    }
}