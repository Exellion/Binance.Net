using System.Collections.Generic;

namespace BinanceAPI.Models
{
    public class BinanceExchangeInfo
    {
        public string TimeZone { get; set; }

        public long ServerTime { get; set; }

        public List<BinanceRateLimit> RateLimits { get; set; }

        public BinanceExchangeFilters Filters { get; set; }

        public List<BinanceTicker> Symbols { get; set; }
    }
}
