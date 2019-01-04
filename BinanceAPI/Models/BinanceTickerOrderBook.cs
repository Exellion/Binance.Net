using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceTickerOrderBook
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bidPrice")]
        public decimal BidPrice { get; set; }    

        [JsonProperty("bidQty")]
        public decimal BidQuantity { get; set; }

        [JsonProperty("askPrice")]
        public decimal AskPrice { get; set; }

        [JsonProperty("askQty")]
        public decimal AskQuantity { get; set; }
    }
}