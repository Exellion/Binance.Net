using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceBookDepthJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var bookDepth = new BinanceBookDepth();

            var container = serializer.Deserialize<JContainer>(reader);

            foreach (JArray item in container)
            {
                try
                {
                    decimal price = item[0].Value<decimal>();
                    decimal quantity = item[1].Value<decimal>();

                    bookDepth.Add(price, quantity);
                }
                catch
                { }
            }

            return bookDepth;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }
    }
}