using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceAggregateTrade
    {
        [JsonProperty("a")]
        public long AggregateTradeId { get; set; }

        [JsonProperty("p")]
        public decimal Price { get; set; }

        [JsonProperty("q")]
        public decimal Quantity { get; set; }

        [JsonProperty("f")]
        public long FirstTradeId { get; set; }

        [JsonProperty("l")]
        public long LastTradeId { get; set; }

        [JsonProperty("T")]
        public long Timestamp { get; set; }

        [JsonProperty("m")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty("M")]
        public bool IsBestMatch { get; set; }

        public override string ToString() => 
            $"AggregateTrade. AggregateTradeId - {this.AggregateTradeId}; " +
            $"Price - {this.Price}; " +
            $"Quantity - {this.Quantity}; " +
            $"Time - {this.Timestamp}";
    }
}
