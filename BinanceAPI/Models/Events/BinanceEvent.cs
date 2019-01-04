using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public abstract class BinanceEvent
    {
        [JsonProperty("e")]
        public BinanceEventType Type { get; set; }

        [JsonProperty("E")]
        public long EventTime { get; set; }

        public override string ToString() => $"{this.Type}. EventTime: {this.EventTime}";
    }
}