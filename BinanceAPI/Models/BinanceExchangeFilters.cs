using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceExchangeFiltersJsonConverter))]
    public class BinanceExchangeFilters
    {
        public int MaxNumOrders { get; set; }

        public int MaxAlgoOrders { get; set; }
    }
}
