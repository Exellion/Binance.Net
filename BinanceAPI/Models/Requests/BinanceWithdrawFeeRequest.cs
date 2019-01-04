namespace BinanceAPI.Models
{
    public class BinanceWithdrawFeeRequest : BinanceRequest
    {
        public string Asset { get; set; }

        internal override string BuildRequestString() => 
            $"asset={this.Asset}" +
            $"&{base.BuildRequestString()}";
    }
}