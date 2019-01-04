using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceSystemStatus
    {
        [JsonProperty("status")]
        public BinanceSystemStatusEnum Status { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}