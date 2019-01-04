using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceEventUserDataJsonConverter))]
    public class BinanceEventUserData : BinanceEvent
    {
        public BinanceEventAccountUpdate AccountUpdate { get; internal set; }

        public BinanceEventOrderUpdate OrderUpdate { get; internal set; }
    }
}