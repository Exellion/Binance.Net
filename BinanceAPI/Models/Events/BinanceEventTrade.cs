using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventTrade : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("t")]
        public long TradeId { get; set; }

        [JsonProperty("p")]
        public decimal Price { get; set; }

        [JsonProperty("q")]
        public decimal Quantity { get; set; }

        [JsonProperty("b")]
        public long BuyerOrderId { get; set; }

        [JsonProperty("a")]
        public long SellerOrderId { get; set; }

        [JsonProperty("T")]
        public long TradeTime { get; set; }

        [JsonProperty("m")]
        public bool IsBuyerMarketMaker { get; set; }

        [JsonProperty("M")]
        internal bool Ignore { get; set; }

        public override string ToString() => 
            $"{base.ToString()}; " +
            $"Symbol: {this.Symbol}; " +
            $"TradeId: {this.TradeId}; " +
            $"Price: {this.Price}; " +
            $"Quantity: {this.Quantity}; " +
            $"BuyerOrderId: {this.BuyerOrderId}; " +
            $"SellerOrderId: {this.SellerOrderId}; " +
            $"TradeTime: {this.TradeTime}; " +
            $"IsBuyerMarketMaker: {this.IsBuyerMarketMaker}";
    }
}
