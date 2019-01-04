namespace BinanceAPI.Models
{
    public class BinanceOpenOrdersRequest : BinanceRequest
    {
        public string Symbol { get; set; }

        internal override string BuildRequestString() => 
            $"{base.BuildRequestString()}" +
            $"{TryGetRequestParameter(this.Symbol, "symbol")}";
    }
}