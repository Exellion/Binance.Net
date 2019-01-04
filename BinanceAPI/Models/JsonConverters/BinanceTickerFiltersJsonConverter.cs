using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceTickerFiltersJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var filters = new BinanceTickerFilters();

            try
            {
                var container = serializer.Deserialize<JContainer>(reader);

                foreach(JToken item in container)
                {
                    string filterType = item["filterType"].Value<string>();

                    switch(filterType)
                    {
                        case "PRICE_FILTER":
                            filters.MinPrice = item["minPrice"].Value<decimal>();
                            filters.MaxPrice = item["maxPrice"].Value<decimal>();
                            filters.TickSize = item["tickSize"].Value<decimal>();
                            break;
                        case "LOT_SIZE":
                            filters.MinQuantity = item["minQty"].Value<decimal>();
                            filters.MaxQuantity = item["maxQty"].Value<decimal>();
                            filters.StepSize = item["stepSize"].Value<decimal>();
                            break;
                        case "MIN_NOTIONAL":
                            filters.MinNotional = item["minNotional"].Value<decimal>();
                            break;
                    }
                }
            }
            catch
            {

            }

            return filters;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { }
    }
}
