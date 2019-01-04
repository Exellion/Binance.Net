using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceServerTime
    {
        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }
    }
}