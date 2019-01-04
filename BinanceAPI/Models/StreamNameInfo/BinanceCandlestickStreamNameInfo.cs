namespace BinanceAPI.Models
{
    public class BinanceCandlestickStreamNameInfo : BinanceSymbolStreamNameInfo
    {
        protected override string StreamName => "kline_";

        public BinanceChartInterval Interval { get; private set; }

        public BinanceCandlestickStreamNameInfo(string symbol, BinanceChartInterval interval)
            : base(symbol) => this.Interval = interval;

        public override string BuildStreamFullName() => $"{base.BuildStreamFullName()}{this.Interval.Format()}";

        internal override BinanceEvent DeserializeJson(string json) => DeserializeJson<BinanceEventKline>(json);
    }
}