namespace BinanceAPI.Models
{
    public class BinancePartialBookDepthStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "depth";

        public int Levels { get; private set; }

        public BinancePartialBookDepthStreamNameInfo(string symbol, int levels)
            : base(symbol) => this.Levels = levels;

        public override string BuildStreamFullName() => $"{base.BuildStreamFullName()}{this.Levels}";

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventPartialBookDepth>(json);
    }
}