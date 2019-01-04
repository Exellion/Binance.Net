using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceDepositAddress
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("addressTag")]
        public string AddressTag { get; set; }

        [JsonProperty("asset")]
        public string Asset { get; set; }
    }
}