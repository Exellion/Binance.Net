using BinanceAPI.Models.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(BinanceBookDepthJsonConverter))]
    public class BinanceBookDepth : Dictionary<decimal, decimal>
    {

    }
}
