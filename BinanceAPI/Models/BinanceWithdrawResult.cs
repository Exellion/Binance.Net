using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceWithdrawResult
    {
        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}