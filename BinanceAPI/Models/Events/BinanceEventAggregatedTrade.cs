using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventAggregatedTrade : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("a")]
        public long AggregatedTradeId { get; set; }

        [JsonProperty("p")]
        public decimal Price { get; set; }

        [JsonProperty("q")]
        public decimal Quantity { get; set; }

        [JsonProperty("f")]
        public long FirstTradeId { get; set; }

        [JsonProperty("l")]
        public long LastTradeId { get; set; }

        [JsonProperty("T")]
        public long TradeTime { get; set; }

        [JsonProperty("m")]
        public bool IsBuyerMarketMaker { get; set; }

        [JsonProperty("M")]
        internal bool Ignore { get; set; }

        public override string ToString() =>
            $"{base.ToString()}; " +
            $"Symbol: {this.Symbol}; " +
            $"AggregatedTradeId: {this.AggregatedTradeId}; " +
            $"Price: {this.Price}; " +
            $"Quantity: {this.Quantity}; " +
            $"FirstTradeId: {this.FirstTradeId}; " +
            $"LastTradeId: {this.LastTradeId}; " +
            $"TradeTime: {this.TradeTime}; " +
            $"IsBuyerMarketMaker: {this.IsBuyerMarketMaker}";
    }
}
