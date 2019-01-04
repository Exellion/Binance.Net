namespace BinanceAPI.Models
{
    public class BinanceTicker24hrStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "ticker";

        public BinanceTicker24hrStreamNameInfo(string symbol)
            : base(symbol)
        { }

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventTicker>(json);
    }
}