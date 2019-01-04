using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public abstract class BinanceStreamNameInfo
    {
        protected abstract string StreamName { get; }

        internal abstract BinanceEvent DeserializeJson(string json);

        public abstract string BuildStreamFullName();

        protected TEvent DeserializeJson<TEvent>(string json)
            where TEvent : BinanceEvent => JsonConvert.DeserializeObject<TEvent>(json);
    }
}