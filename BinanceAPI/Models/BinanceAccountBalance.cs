using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceAccountBalance
    {
        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("free")]
        public decimal Free { get; set; }

        [JsonProperty("locked")]
        public decimal Locked { get; set; }
    }
}