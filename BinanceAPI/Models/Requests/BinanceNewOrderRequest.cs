namespace BinanceAPI.Models
{
    public class BinanceNewOrderRequest : BinanceRequest
    {
        public string Symbol { get; set; }

        public BinanceOrderSide Side { get; set; }

        public BinanceOrderType OrderType { get; set; }

        public BinanceTimeInForce? TimeInForce { get; set; }

        public decimal Quantity { get; set; }

        public decimal? Price { get; set; }

        public string NewClientOrderId { get; set; }

        public decimal? StopPrice { get; set; }

        public decimal? IcebergQuantity { get; set; }

        public BinanceOrderResponseType? ResponseType { get; set; }

        internal override string BuildRequestString() =>
            $"symbol={this.Symbol}" +
            $"&side={this.Side.Format()}" +
            $"&type={this.OrderType.Format()}" +
            $"{TryGetRequestParameterForEnum(this.TimeInForce, "timeInForce")}" +
            $"&quantity={this.Quantity.ToString(EnUsCulture)}" +
            $"{TryGetRequestParameterForDecimal(this.Price, "price")}" +
            $"{TryGetRequestParameter(this.NewClientOrderId, "newClientOrderId")}" +
            $"{TryGetRequestParameterForDecimal(this.StopPrice, "stopPrice")}" +
            $"{TryGetRequestParameterForDecimal(this.IcebergQuantity, "icebergQty")}" +
            $"{TryGetRequestParameterForEnum(this.ResponseType, "newOrderRespType")}" +
            $"&{base.BuildRequestString()}";
    }
}
