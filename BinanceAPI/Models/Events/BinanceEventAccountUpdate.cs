using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceEventAccountUpdate : BinanceEvent
    {
        [JsonProperty("m")]
        public decimal MakerCommission { get; set; }

        [JsonProperty("t")]
        public decimal TakerCommission { get; set; }

        [JsonProperty("b")]
        public decimal BuyerCommission { get; set; }

        [JsonProperty("s")]
        public decimal SellerCommission { get; set; }

        [JsonProperty("T")]
        public bool CanTrade { get; set; }

        [JsonProperty("W")]
        public bool CanWithdraw { get; set; }

        [JsonProperty("D")]
        public bool CanDeposit { get; set; }

        [JsonProperty("u")]
        public long UpdateTime { get; set; }

        [JsonProperty("B")]
        public List<BinanceAccountBalance> Balances { get; set; }
    }
}