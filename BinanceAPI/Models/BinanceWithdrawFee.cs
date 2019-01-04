using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceWithdrawFee
    {
        [JsonProperty("withdrawFee")]
        public decimal Fee { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}