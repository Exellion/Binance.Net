using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceOrderFill
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("qty")]
        public decimal Quantity { get; set; }

        [JsonProperty("commission")]
        public decimal Comission { get; set; }

        [JsonProperty("commissionAsset")]
        public string ComissionAsset { get; set; }
    }
}