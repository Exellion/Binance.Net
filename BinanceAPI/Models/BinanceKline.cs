using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceKline
    {
        [JsonProperty("t")]
        public long StartTime { get; set; }

        [JsonProperty("T")]
        public long CloseTime { get; set; }

        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("i")]
        public BinanceChartInterval Interval { get; set; }

        [JsonProperty("f")]
        public long FirstTradeId { get; set; }

        [JsonProperty("L")]
        public long LastTradeId { get; set; }

        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }

        [JsonProperty("c")]
        public decimal ClosePrice { get; set; }

        [JsonProperty("h")]
        public decimal HighPrice { get; set; }

        [JsonProperty("l")]
        public decimal LowPrice { get; set; }

        [JsonProperty("v")]
        public decimal BaseAssetVolume { get; set; }

        [JsonProperty("n")]
        public long NumberOfTrades { get; set; }

        [JsonProperty("x")]
        public bool IsClosed { get; set; }

        [JsonProperty("q")]
        public decimal QuoteAssetVolume { get; set; }

        [JsonProperty("V")]
        public decimal TakerBuyBaseAssetVolume { get; set; }

        [JsonProperty("Q")]
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        [JsonProperty("B")]
        internal long Ignore { get; set; }

        public override string ToString() =>
            $"{base.ToString()}; " +
            $"StartTime: {this.StartTime}; " +
            $"CloseTime: {this.CloseTime}; " +
            $"Symbol: {this.Symbol}; " +
            $"Interval: {this.Interval}; " +
            $"FirstTradeId: {this.FirstTradeId}; " +
            $"LastTradeId: {this.LastTradeId}; " +
            $"OpenPrice: {this.OpenPrice}; " +
            $"ClosePrice: {this.ClosePrice}; " +
            $"HighPrice: {this.HighPrice}; " +
            $"LowPrice: {this.LowPrice}; " +
            $"BaseAssetVolume: {this.BaseAssetVolume}; " +
            $"NumberOfTrades: {this.NumberOfTrades}; " +
            $"IsClosed: {this.IsClosed}; " +
            $"QuoteAssetVolume: {this.QuoteAssetVolume}; " +
            $"TakerBuyBaseAssetVolume: {this.TakerBuyBaseAssetVolume}; " +
            $"TakerBuyQuoteAssetVolume: {this.TakerBuyQuoteAssetVolume}";
    }
}
