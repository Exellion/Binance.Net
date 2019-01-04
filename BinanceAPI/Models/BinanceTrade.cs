using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceTrade
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        [JsonProperty("commission")]
        public decimal Comission { get; set; }

        [JsonProperty("commissionAsset")]
        public string ComissionAsset { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("isBuyerMaker")]
        public bool? IsBuyerMaker { get; set; }

        [JsonProperty("isBuyer")]
        public bool? IsBuyer { get; set; }

        [JsonProperty("isMaker")]
        public bool? IsMaker { get; set; }

        [JsonProperty("isBestMatch")]
        public bool? IsBestMatch { get; set; }

        public override string ToString() => $"Trade. Id - {this.Id}; Price - {this.Price}; Quantity - {this.Quantity}; Time - {this.Time}";
    }
}