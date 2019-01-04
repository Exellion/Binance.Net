using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceEventOrderUpdate : BinanceEvent
    {
        [JsonProperty("s")]
        public string Symbol { get; set; }

        [JsonProperty("c")]
        public string ClientOrderId { get; set; }

        [JsonProperty("S")]
        public BinanceOrderSide Side { get; set; }

        [JsonProperty("o")]
        public BinanceOrderType OrderType { get; set; }

        [JsonProperty("f")]
        public BinanceTimeInForce TimeInForce { get; set; }

        [JsonProperty("q")]
        public decimal OrderQuantity { get; set; }

        [JsonProperty("p")]
        public decimal OrderPrice { get; set; }

        [JsonProperty("P")]
        public decimal StopPrice { get; set; }

        [JsonProperty("F")]
        public decimal IcebergQuantity { get; set; }

        [JsonProperty("C")]
        public string OriginalClientOrderId { get; set; }

        [JsonProperty("x")]
        public BinanceExecutionType ExecutionType { get; set; }

        [JsonProperty("X")]
        public BinanceOrderStatus OrderStatus { get; set; }

        [JsonProperty("r")]
        public string OrderRejectErrorCode { get; set; }

        [JsonProperty("i")]
        public long OrderId { get; set; }

        [JsonProperty("l")]
        public decimal LastExecutedQuantity { get; set; }

        [JsonProperty("z")]
        public decimal CumulativeFilledQuantity { get; set; }

        [JsonProperty("L")]
        public decimal LastExecutedPrice { get; set; }

        [JsonProperty("n")]
        public decimal Commission { get; set; }

        [JsonProperty("N")]
        public string CommissionAsset { get; set; }

        [JsonProperty("T")]
        public long TransactionTime { get; set; }

        [JsonProperty("t")]
        public long TradeId { get; set; }

        [JsonProperty("w")]
        public bool IsOrderWorking { get; set; }

        [JsonProperty("m")]
        public bool IsTradeMakerSide { get; set; }


        [JsonProperty("g")]
        internal long Ignore1 { get; set; }

        [JsonProperty("I")]
        internal long Ignore2 { get; set; }

        [JsonProperty("M")]
        internal bool Ignore3 { get; set; }

        [JsonProperty("O")]
        internal long Ignore4 { get; set; }

        [JsonProperty("Z")]
        internal decimal Ignore5 { get; set; }
    }
}