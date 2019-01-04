using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BinanceAPI.Models.JsonConverters
{
    class BinanceExchangeFiltersJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var filters = new BinanceExchangeFilters();

            try
            {
                var container = serializer.Deserialize<JContainer>(reader);

                foreach (JToken item in container)
                {
                    string filterType = item["filterType"].Value<string>();

                    switch (filterType)
                    {
                        case "EXCHANGE_MAX_NUM_ORDERS":
                            filters.MaxNumOrders = item["limit"].Value<int>();
                            break;
                        case "EXCHANGE_MAX_ALGO_ORDERS":
                            filters.MaxAlgoOrders = item["limit"].Value<int>();
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
