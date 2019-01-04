using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventTicker : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("p")]
        public decimal PriceChange { get; set; }

        [JsonProperty("P")]
        public decimal PriceChangePercent { get; set; }

        [JsonProperty("w")]
        public decimal WeightedAveragePrice { get; set; }

        [JsonProperty("x")]
        public decimal PreviousDayClosePrice { get; set; }

        [JsonProperty("c")]
        public decimal CurrentDayClosePrice { get; set; }

        [JsonProperty("Q")]
        public decimal CloseTradesQuantity { get; set; }

        [JsonProperty("b")]
        public decimal BestBidPrice { get; set; }

        [JsonProperty("B")]
        public decimal BestBidQuantity { get; set; }

        [JsonProperty("a")]
        public decimal BestAskPrice { get; set; }

        [JsonProperty("A")]
        public decimal BestAskQuantity { get; set; }

        [JsonProperty("o")]
        public decimal OpenPrice { get; set; }

        [JsonProperty("h")]
        public decimal HighPrice { get; set; }

        [JsonProperty("l")]
        public decimal LowPrice { get; set; }

        [JsonProperty("v")]
        public decimal TotalTradedBaseAssetVolume { get; set; }

        [JsonProperty("q")]
        public decimal TotalTradedQuoteAssetVolume { get; set; }

        [JsonProperty("O")]
        public long StatisticsOpenTime { get; set; }

        [JsonProperty("C")]
        public long StatisticsCloseTime { get; set; }

        [JsonProperty("F")]
        public long FirstTradeId { get; set; }

        [JsonProperty("L")]
        public long LastTradeId { get; set; }

        [JsonProperty("n")]
        public long TotalNumberOfTrades { get; set; }

        public override string ToString() =>
            $"{base.ToString()}; " +
            $"Symbol: {this.Symbol}; " +
            $"PriceChange: {this.PriceChange}; " +
            $"PriceChangePercent: {this.PriceChangePercent}; " +
            $"WeightedAveragePrice: {this.WeightedAveragePrice}; " +
            $"PreviousDayClosePrice: {this.PreviousDayClosePrice}; " +
            $"CurrentDayClosePrice: {this.CurrentDayClosePrice}; " +
            $"CloseTradesQuantity: {this.CloseTradesQuantity}; " +
            $"BestBidPrice: {this.BestBidPrice}; " +
            $"BestBidQuantity: {this.BestBidQuantity}; " +
            $"BestAskPrice: {this.BestAskPrice}; " +
            $"BestAskQuantity: {this.BestAskQuantity}; " +
            $"OpenPrice: {this.OpenPrice}; " +
            $"HighPrice: {this.HighPrice}; " +
            $"LowPrice: {this.LowPrice}; " +
            $"TotalTradedBaseAssetVolume: {this.TotalTradedBaseAssetVolume}; " +
            $"TotalTradedQuoteAssetVolume: {this.TotalTradedQuoteAssetVolume}; " +
            $"StatisticsOpenTime: {this.StatisticsOpenTime}; " +
            $"StatisticsCloseTime: {this.StatisticsCloseTime}; " +
            $"FirstTradeId: {this.FirstTradeId}; " +
            $"LastTradeId: {this.LastTradeId}; " +
            $"TotalNumberOfTrades: {this.TotalNumberOfTrades}";
    }
}
