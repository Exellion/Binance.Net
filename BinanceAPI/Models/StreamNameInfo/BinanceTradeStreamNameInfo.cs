namespace BinanceAPI.Models
{
    public class BinanceTradeStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "trade";

        public BinanceTradeStreamNameInfo(string symbol)
            : base(symbol)
        { }

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventTrade>(json);
    }
}