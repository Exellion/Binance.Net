using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceAccountInformation
    {
        [JsonProperty("makerCommission")]
        public decimal MakerCommission { get; set; }

        [JsonProperty("takerCommission")]
        public decimal TakerCommission { get; set; }

        [JsonProperty("buyerCommission")]
        public decimal BuyerCommission { get; set; }

        [JsonProperty("sellerCommission")]
        public decimal SellerCommission { get; set; }

        [JsonProperty("canTrade")]
        public bool CanTrade { get; set; }

        [JsonProperty("canWithdraw")]
        public bool CanWithdraw { get; set; }

        [JsonProperty("canDeposit")]
        public bool CanDeposit { get; set; }

        [JsonProperty("updateTime")]
        public long UpdateTime { get; set; }

        [JsonProperty("balances")]
        public List<BinanceAccountBalance> Balances { get; set; }
    }
}