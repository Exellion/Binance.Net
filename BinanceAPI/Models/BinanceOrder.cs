using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceOrder
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("transactTime")]
        public long TransactTime { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("stopPrice")]
        public decimal StopPrice { get; set; }

        [JsonProperty("origQty")]
        public decimal OriginQuantity { get; set; }

        [JsonProperty("executedQty")]
        public decimal ExecutedQuantity { get; set; }

        [JsonProperty("icebergQty")]
        public decimal IcebergQuantity { get; set; }

        [JsonProperty("status")]
        public BinanceOrderStatus Status { get; set; }

        [JsonProperty("timeInForce")]
        public BinanceTimeInForce TimeInForce { get; set; }

        [JsonProperty("type")]
        public BinanceOrderType Type { get; set; }

        [JsonProperty("side")]
        public BinanceOrderSide Side { get; set; }

        [JsonProperty("isWorking")]
        public bool IsWorking { get; set; }

        [JsonProperty("fills")]
        public List<BinanceOrderFill> Fills { get; set; }
    }
}