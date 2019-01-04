using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceWithdrawHistory
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("withdrawList")]
        public List<BinanceWithdraw> WithdrawList { get; set; }
    }
}