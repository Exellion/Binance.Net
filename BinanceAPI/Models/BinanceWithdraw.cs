using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceWithdraw
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("applyTime")]
        public long ApplyTime { get; set; }

        [JsonProperty("status")]
        public BinanceWithdrawStatus Status { get; set; }
    }
}