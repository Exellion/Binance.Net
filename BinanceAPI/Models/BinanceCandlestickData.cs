﻿using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceCandlestickDataJsonConverter))]
    public class BinanceCandlestickData
    {
        public long OpenTime { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public long CloseTime { get; set; }

        public decimal QuoteAssetVolume { get; set; }

        public int NumberOfTrades { get; set; }

        public decimal TakerBuyBaseAssetVolume { get; set; }

        public decimal TakerBuyQuoteAssetVolume { get; set; }
    }
}