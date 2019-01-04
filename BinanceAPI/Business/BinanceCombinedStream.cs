using BinanceAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocket4Net;

namespace BinanceAPI.Business
{
    class BinanceCombinedStream : BinanceStream<BinanceEvent>
    {
        protected override string SocketUri => $"{this.baseEndpoint}/stream?streams={this.Name}";

        private Dictionary<string, BinanceStreamNameInfo> streamInfoCache;

        public BinanceCombinedStream(string baseEndpoint, string name, params BinanceStreamNameInfo[] infoItems)
            :base(baseEndpoint, string.Empty)
        {
            this.Name = name;

            this.streamInfoCache = new Dictionary<string, BinanceStreamNameInfo>();

            for(int i = 0; i < infoItems.Length; i++)
            {
                var infoItem = infoItems[i];

                string streamName = infoItem.BuildStreamFullName();

                this.streamInfoCache[streamName] = infoItem;
            }
        }

        protected override void Socket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var container = JsonConvert.DeserializeObject<JContainer>(e.Message);

                var binanceEvent = this.streamInfoCache[container["stream"].Value<string>()].DeserializeJson(container["data"].ToString());

                if (binanceEvent != null)
                    OnEventReceived(binanceEvent);
            }
            catch(Exception ex)
            {
                OnError(ex);
            }
        }

        internal static string CombineStreamName(BinanceStreamNameInfo[] infoItems)
        {
            if (infoItems.Length == 0)
                throw new ArgumentException($"At least one {nameof(BinanceStreamNameInfo)} item must be send");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < infoItems.Length; i++)
            {
                var infoItem = infoItems[i];

                string streamName = infoItem.BuildStreamFullName();

                sb.Append(streamName);

                if (i < infoItems.Length - 1)
                    sb.Append("/");
            }

            return sb.ToString();
        }
    }
}