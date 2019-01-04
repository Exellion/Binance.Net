namespace BinanceAPI.Models
{
    class BinanceEmptyStreamNameInfo : BinanceStreamNameInfo
    {
        protected override string StreamName => this.streamName;

        private string streamName;

        public BinanceEmptyStreamNameInfo(string streamName) => this.streamName = streamName;

        public override string BuildStreamFullName() => this.streamName;

        internal override BinanceEvent DeserializeJson(string json) => null;
    }
}