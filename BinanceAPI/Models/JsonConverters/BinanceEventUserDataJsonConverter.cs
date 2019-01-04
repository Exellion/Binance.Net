using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceEventUserDataJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            BinanceEventUserData binanceEvent = new BinanceEventUserData();

            var container = serializer.Deserialize<JContainer>(reader);

            var eventType = container["e"].Value<string>();

            switch(eventType)
            {
                case "outboundAccountInfo":
                    binanceEvent.AccountUpdate = JsonConvert.DeserializeObject<BinanceEventAccountUpdate>(container.ToString());

                    JArray balances = container.Value<JArray>("B");

                    for(int i = 0; i < balances.Count; i++)
                    {
                        var balance = balances[i];
                        var eventBalance = binanceEvent.AccountUpdate.Balances[i];

                        eventBalance.Asset = balance["a"].Value<string>();
                        eventBalance.Free = balance["f"].Value<decimal>();
                        eventBalance.Locked = balance["l"].Value<decimal>();
                    }

                    binanceEvent.Type = binanceEvent.AccountUpdate.Type;
                    binanceEvent.EventTime = binanceEvent.AccountUpdate.EventTime;
                    break;
                case "executionReport":
                    binanceEvent.OrderUpdate = JsonConvert.DeserializeObject<BinanceEventOrderUpdate>(container.ToString());

                    binanceEvent.Type = binanceEvent.OrderUpdate.Type;
                    binanceEvent.EventTime = binanceEvent.OrderUpdate.EventTime;
                    break;
            }

            return binanceEvent;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }
    }
}