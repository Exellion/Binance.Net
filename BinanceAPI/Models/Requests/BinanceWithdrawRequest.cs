namespace BinanceAPI.Models
{
    public class BinanceWithdrawRequest : BinanceRequest
    {
        public string Asset { get; set; }

        public string Address { get; set; }

        public string AddressTag { get; set; }

        public decimal Amount { get; set; }

        public string Name { get; set; }

        internal override string BuildRequestString() =>
            $"asset={this.Asset}" +
            $"&address={this.Address}" +
            $"{TryGetRequestParameter(this.AddressTag, "addressTag")}" +
            $"&amount={this.Amount.ToString(EnUsCulture)}" +
            $"{TryGetRequestParameter(this.Name, "name")}" +
            $"&{base.BuildRequestString()}";
    }
}