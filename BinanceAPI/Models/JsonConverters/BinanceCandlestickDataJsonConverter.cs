using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceCandlestickDataJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            BinanceCandlestickData binanceCandlestickData = null;

            var jArray = serializer.Deserialize<JArray>(reader);

            try
            {
                binanceCandlestickData = new BinanceCandlestickData()
                {
                    OpenTime = jArray[0].Value<long>(),
                    Open = jArray[1].Value<decimal>(),
                    High = jArray[2].Value<decimal>(),
                    Low = jArray[3].Value<decimal>(),
                    Close = jArray[4].Value<decimal>(),
                    Volume = jArray[5].Value<decimal>(),
                    CloseTime = jArray[6].Value<long>(),
                    QuoteAssetVolume = jArray[7].Value<decimal>(),
                    NumberOfTrades = jArray[8].Value<int>(),
                    TakerBuyBaseAssetVolume = jArray[9].Value<decimal>(),
                    TakerBuyQuoteAssetVolume = jArray[10].Value<decimal>()
                };
            }
            catch
            { }

            return binanceCandlestickData;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }
    }
}