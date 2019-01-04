using Newtonsoft.Json;

namespace BinanceAPI.Models
{
    public class BinanceResponse<TContent>
    {
        [JsonProperty("code")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string ErrorMessage { get; set; }

        public TContent Content { get; set; }
    }
}