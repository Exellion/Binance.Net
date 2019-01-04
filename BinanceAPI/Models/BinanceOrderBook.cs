using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceOrderBook
    {
        [JsonProperty("lastUpdateId")]
        public long LastUpdateId { get; set; }

        [JsonProperty("bids")]
        public BinanceBookDepth Bids { get; set; }

        [JsonProperty("asks")]
        public BinanceBookDepth Asks { get; set; }
    }
}
