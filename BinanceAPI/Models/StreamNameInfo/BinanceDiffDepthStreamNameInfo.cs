namespace BinanceAPI.Models
{
    public class BinanceDiffDepthStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "depth";

        public BinanceDiffDepthStreamNameInfo(string symbol)
            : base(symbol)
        { }

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventDiffDepth>(json);
    }
}