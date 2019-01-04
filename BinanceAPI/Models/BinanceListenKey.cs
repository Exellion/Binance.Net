using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceListenKey
    {
        [JsonProperty("listenKey")]
        public string ListenKey { get; set; }
    }
}
