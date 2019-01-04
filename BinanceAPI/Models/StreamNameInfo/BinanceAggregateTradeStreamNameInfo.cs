namespace BinanceAPI.Models
{
    public class BinanceAggregateTradeStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "aggTrade";

        public BinanceAggregateTradeStreamNameInfo(string symbol)
            :base(symbol)
        { }

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventAggregatedTrade>(json);
    }
}