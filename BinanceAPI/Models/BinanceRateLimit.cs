using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceRateLimit
    {
        [JsonProperty("rateLimitType")]
        public BinanceRateLimiters Type { get; set; }

        [JsonProperty("interval")]
        public BinanceRateLimitIntervals Interval { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        public override string ToString() => $"{this.Type} - {this.Interval} - {this.Limit}";
    }
}
