using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceDeposit
    {
        [JsonProperty("insertTime")]
        public long InsertTime { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("asset")]
        public string Asset { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("status")]
        public BinanceDepositStatus Status { get; set; }
    }
}