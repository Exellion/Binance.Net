using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceAccountStatus
    {
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("objs")]
        public string[] Parameters { get; set; }
    }
}