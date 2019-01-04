using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceTickerPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
