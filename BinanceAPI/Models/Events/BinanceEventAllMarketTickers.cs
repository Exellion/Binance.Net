using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceEventAllMarketTickersJsonConverter))]
    public class BinanceEventAllMarketTickers : BinanceEvent
    {
        public List<BinanceEventTicker> Tickers { get; set; }
    }
}
