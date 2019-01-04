using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceDepositHistory
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("depositList")]
        public List<BinanceDeposit> DepositList { get; set; }
    }
}