using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventKline : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("k")]
        public BinanceKline Kline { get; set; }

        public override string ToString() =>
            $"{base.ToString()}; " +
            $"Symbol: {this.Symbol}; " +
            $"Kline: {this.Kline}";
    }
}
