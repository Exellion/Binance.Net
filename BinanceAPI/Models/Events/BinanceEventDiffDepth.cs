using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventDiffDepth : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("U")]
        public long FirstUpdateId { get; set; }

        [JsonProperty("u")]
        public long FinalUpdateId { get; set; }

        [JsonProperty("b")]
        public BinanceBookDepth Bids { get; set; }

        [JsonProperty("a")]
        public BinanceBookDepth Asks { get; set; }
    }
}
