namespace BinanceAPI.Models
{
    public class BinanceCancelOrderRequest : BinanceQueryOrderRequest
    {
        public string NewClientOderId { get; set; }

        internal override string BuildRequestString() => 
            $"{base.BuildRequestString()}" +
            $"{TryGetRequestParameter(this.NewClientOderId, "newClientOrderId")}";
    }
}