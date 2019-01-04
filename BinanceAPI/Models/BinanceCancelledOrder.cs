using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceCancelledOrder
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("origClientOrderId")]
        public string OriginClientOrderId { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }
    }
}