using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceTickerFiltersJsonConverter))]
    public class BinanceTickerFilters
    {
        public decimal MinPrice { get; set; }

        public decimal MaxPrice { get; set; }

        public decimal TickSize { get; set; }

        public decimal MinQuantity { get; set; }

        public decimal MaxQuantity { get; set; }

        public decimal StepSize { get; set; }

        public decimal MinNotional { get; set; }

        public int MaxNumOrders { get; set; }

        public int MaxAlgoOrders { get; set; }
    }
}
