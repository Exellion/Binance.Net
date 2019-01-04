namespace BinanceAPI.Models
{
    public abstract class BinanceSymbolStreamNameInfo : BinanceStreamNameInfo
    {
        public string Symbol { get; private set; }

        protected BinanceSymbolStreamNameInfo(string symbol) => this.Symbol = symbol.ToLower();

        public override string BuildStreamFullName() => $"{this.Symbol}@{this.StreamName}";
    }
}