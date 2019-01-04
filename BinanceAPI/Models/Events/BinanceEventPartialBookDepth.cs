using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventPartialBookDepth : BinanceEvent
    {
        [JsonProperty("lastUpdateId")]
        public long LastUpdateId { get; set; }

        [JsonProperty("bids")]
        public BinanceBookDepth Bids { get; set; }

        [JsonProperty("asks")]
        public BinanceBookDepth Asks { get; set; }

        public BinanceEventPartialBookDepth() => this.Type = BinanceEventType.PartialBookDepth;
    }
}
