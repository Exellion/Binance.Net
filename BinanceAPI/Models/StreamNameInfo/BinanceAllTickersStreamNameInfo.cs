namespace BinanceAPI.Models
{
    public class BinanceAllTickersStreamNameInfo : BinanceStreamNameInfo
    {
        protected override string StreamName => "!ticker@arr";

        public override string BuildStreamFullName() => this.StreamName;

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventAllMarketTickers>(json);
    }
}