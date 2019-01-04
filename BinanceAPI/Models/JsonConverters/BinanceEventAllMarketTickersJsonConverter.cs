using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceEventAllMarketTickersJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var binanceEvent = new BinanceEventAllMarketTickers()
            {
                Type = BinanceEventType.AllMarketTickers,
                Tickers = new List<BinanceEventTicker>()
            };

            var container = serializer.Deserialize<JContainer>(reader);

            foreach (JToken item in container)
            {
                try
                {
                    var tickerEvent = JsonConvert.DeserializeObject<BinanceEventTicker>(item.ToString());

                    binanceEvent.Tickers.Add(tickerEvent);
                }
                catch
                { }
            }

            return binanceEvent;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }
    }
}
