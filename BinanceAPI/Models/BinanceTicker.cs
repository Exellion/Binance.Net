using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceTicker
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("status")]
        public BinanceSymbolStatus Status { get; set; }

        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }

        [JsonProperty("baseAssetPrecision")]
        public int BaseAssetPrecision { get; set; }

        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }

        [JsonProperty("quotePrecision")]
        public int QuoteAssetPrecision { get; set; }

        [JsonProperty("orderTypes")]
        public List<BinanceOrderType> OrderTypes { get; set; }

        [JsonProperty("icebergAllowed")]
        public bool IcebergAllowed { get; set; }

        [JsonProperty("filters")]
        public BinanceTickerFilters Filters { get; set; }

        public override string ToString() => $"{this.Symbol}. Status - {this.Status}; Order types: {string.Join(", ", this.OrderTypes)}; Allow iceberg - {this.IcebergAllowed}";
    }
}