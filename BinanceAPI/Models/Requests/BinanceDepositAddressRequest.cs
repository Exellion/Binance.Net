namespace BinanceAPI.Models
{
    public class BinanceDepositAddressRequest : BinanceRequest
    {
        public string Asset { get; set; }

        public bool? Status { get; set; }

        internal override string BuildRequestString() => 
            $"asset={this.Asset}" +
            $"{TryGetRequestParameter(this.Status, "status")}" +
            $"&{base.BuildRequestString()}";
    }
}