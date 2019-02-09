using BinanceAPI.Business;
using BinanceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinanceAPI
{
    public class BinanceClient : IDisposable
    {
        public event BinanceStreamEventHandler StreamOpened;
        public event BinanceStreamEventHandler StreamClosed;
        public event BinanceStreamEventHandler StreamError;
        public event BinanceStreamEventHandler<BinanceEvent> EventReceived;


        private const string DEFAULT_BASE_ENDPOINT = "https://api.binance.com";
        private const string DEFAULT_SOCKET_BASE_ENDPOINT = "wss://stream.binance.com:9443";

        private const long UNIX_START_TIME_TICKS = 621355968000000000;

        private readonly string socketBaseEndpoint;
        private readonly string apiKey;
        private readonly string secretKey;

        private Dictionary<string, IBinanceStream> streamsCache;
        private object streamsCacheLocker;

        private HttpClient httpClient;

        private bool forbidAllRequests;
        private int forbidMiliseconds;
        private DateTime forbiddenStartTimeUtc;
        private CancellationTokenSource forbidCancellationTokenSource;
        private object forbidLocker;

        public BinanceClient(BinanceClientConfig config = null)
        {
            this.socketBaseEndpoint = config?.SocketBaseEndpoint ?? DEFAULT_SOCKET_BASE_ENDPOINT;

            this.streamsCache = new Dictionary<string, IBinanceStream>();
            this.streamsCacheLocker = new object();

            this.httpClient = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            })
            {
                BaseAddress = new Uri(config?.BaseEndpoint ?? DEFAULT_BASE_ENDPOINT)
            };
            this.httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");

            this.apiKey = config?.ApiKey ?? string.Empty;
            this.secretKey = config?.SecretKey ?? string.Empty;

            this.forbidLocker = new object();
        }

        public void Dispose()
        {
            foreach (var item in this.streamsCache)
                item.Value.CloseAsync()
                    .ContinueWith(t => item.Value.Dispose());

            this.streamsCache.Clear();
        }

        #region Public Rest API
        public async Task<BinanceResponse<object>> TestConnectivity() => await MakeRequestAsync<object>(HttpMethod.Get, "api/v1/ping");

        public async Task<BinanceResponse<BinanceServerTime>> CheckServerTime() => 
            await MakeRequestAsync<BinanceServerTime>(HttpMethod.Get, "api/v1/time");

        public async Task<BinanceResponse<BinanceExchangeInfo>> GetExchangeInformation() => 
            await MakeRequestAsync<BinanceExchangeInfo>(HttpMethod.Get, "api/v1/exchangeInfo");

        public async Task<BinanceResponse<BinanceOrderBook>> GetOrderBook(string symbol, int? limit = null) => 
            await MakeRequestAsync<BinanceOrderBook>(HttpMethod.Get, "api/v1/depth",
                $"symbol={symbol.ToUpper()}" +
                $"{BinanceRequest.TryGetRequestParameter(limit, "limit")}");

        public async Task<BinanceResponse<List<BinanceTrade>>> GetRecentTrades(string symbol, int? limit = null) => 
            await MakeRequestAsync<List<BinanceTrade>>(HttpMethod.Get, "api/v1/trades",
                $"symbol={symbol.ToUpper()}" +
                $"{BinanceRequest.TryGetRequestParameter(limit, "limit")}");

        public async Task<BinanceResponse<List<BinanceAggregateTrade>>> GetAggregateTrades(string symbol, long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null) =>
            await MakeRequestAsync<List<BinanceAggregateTrade>>(HttpMethod.Get, "api/v1/aggTrades",
                $"symbol={symbol.ToUpper()}" +
                $"{BinanceRequest.TryGetRequestParameter(fromId, "fromId")}" +
                $"{BinanceRequest.TryGetRequestParameter(startTime, "startTime")}" +
                $"{BinanceRequest.TryGetRequestParameter(endTime, "endTime")}" +
                $"{BinanceRequest.TryGetRequestParameter(limit, "limit")}");

        public async Task<BinanceResponse<List<BinanceCandlestickData>>> GetCandlestickData(string symbol, BinanceChartInterval interval, long? startTime = null, long? endTime = null, int? limit = null) =>
            await MakeRequestAsync<List<BinanceCandlestickData>>(HttpMethod.Get, "api/v1/klines",
                $"symbol={symbol.ToUpper()}&" +
                $"interval={interval.Format()}" +
                $"{BinanceRequest.TryGetRequestParameter(startTime, "startTime")}" +
                $"{BinanceRequest.TryGetRequestParameter(endTime, "endTime")}" +
                $"{BinanceRequest.TryGetRequestParameter(limit, "limit")}");

        public async Task<BinanceResponse<BinanceTickerStatistics>> GetTickerPriceChangeStatistics(string symbol) => 
            await MakeRequestAsync<BinanceTickerStatistics>(HttpMethod.Get, "api/v1/ticker/24hr", $"symbol={symbol}");

        public async Task<BinanceResponse<BinanceTickerPrice>> GetTickerPrice(string symbol) =>
            await MakeRequestAsync<BinanceTickerPrice>(HttpMethod.Get, "api/v3/ticker/price", $"symbol={symbol}");

        public async Task<BinanceResponse<BinanceTickerOrderBook>> GetTickerOrderBook(string symbol) =>
            await MakeRequestAsync<BinanceTickerOrderBook>(HttpMethod.Get, "api/v3/ticker/bookTicker", $"symbol={symbol}");

        public async Task<BinanceResponse<List<BinanceTickerStatistics>>> GetAllTickerPriceChangeStatistics() =>
            await MakeRequestAsync<List<BinanceTickerStatistics>>(HttpMethod.Get, "api/v1/ticker/24hr");

        public async Task<BinanceResponse<List<BinanceTickerPrice>>> GetAllTickerPrice() =>
            await MakeRequestAsync<List<BinanceTickerPrice>>(HttpMethod.Get, "api/v3/ticker/price");

        public async Task<BinanceResponse<List<BinanceTickerOrderBook>>> GetAllTickerOrderBook() =>
            await MakeRequestAsync<List<BinanceTickerOrderBook>>(HttpMethod.Get, "api/v3/ticker/bookTicker");

        public async Task<BinanceResponse<BinanceSystemStatus>> GetSystemStatus() =>
            await MakeRequestAsync<BinanceSystemStatus>(HttpMethod.Get, "wapi/v3/systemStatus.html");
        #endregion Public Rest API

        #region Market data Rest API
        public async Task<BinanceResponse<List<BinanceTrade>>> GetHistoricalTrades(string symbol, int? limit = null, long? fromId = null) =>
            await MakeSecureRequestAsync<List<BinanceTrade>>(HttpMethod.Get, "api/v1/historicalTrades",
                $"symbol={symbol.ToUpper()}" +
                $"{BinanceRequest.TryGetRequestParameter(limit, "limit")}" +
                $"{BinanceRequest.TryGetRequestParameter(fromId, "fromId")}", 
                false);
        #endregion Market data Rest API

        #region User data Rest API
        public async Task<BinanceResponse<List<BinanceOrder>>> GetOpenOrders(BinanceOpenOrdersRequest request) =>
            await MakeSecureRequestAsync<List<BinanceOrder>>(HttpMethod.Get, "api/v3/openOrders", request.BuildRequestString());

        public async Task<BinanceResponse<List<BinanceOrder>>> GetAllOrders(BinanceAllOrdersRequest request) =>
            await MakeSecureRequestAsync<List<BinanceOrder>>(HttpMethod.Get, "api/v3/allOrders", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceAccountInformation>> GetAccountInformation(BinanceAccountRequest request) =>
            await MakeSecureRequestAsync<BinanceAccountInformation>(HttpMethod.Get, "api/v3/account", request.BuildRequestString());

        public async Task<BinanceResponse<List<BinanceTrade>>> GetAccountTradeList(BinanceAccountTradesRequest request) =>
            await MakeSecureRequestAsync<List<BinanceTrade>>(HttpMethod.Get, "api/v3/myTrades", request.BuildRequestString());



        public async Task<BinanceResponse<BinanceListenKey>> CreateListenKey() =>
            await MakeSecureRequestAsync<BinanceListenKey>(HttpMethod.Post, "api/v1/userDataStream", string.Empty, false);

        public async Task<BinanceResponse<object>> KeepAliveListenKey(string listenKey) =>
            await MakeSecureRequestAsync<object>(HttpMethod.Put, "api/v1/userDataStream", $"listenKey={listenKey}", false);

        public async Task<BinanceResponse<object>> CloseListenKey(string listenKey) =>
            await MakeSecureRequestAsync<object>(HttpMethod.Delete, "api/v1/userDataStream", $"listenKey={listenKey}", false);


        public async Task<BinanceResponse<BinanceWithdrawResult>> Withdraw(BinanceWithdrawRequest request) =>
            await MakeSecureRequestAsync<BinanceWithdrawResult>(HttpMethod.Post, "wapi/v3/withdraw.html", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceDepositHistory>> GetDepositHistory(BinanceDepositHistoryRequest request) =>
            await MakeSecureRequestAsync<BinanceDepositHistory>(HttpMethod.Get, "wapi/v3/depositHistory.html", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceWithdrawHistory>> GetWithdrawHistory(BinanceWithdrawHistoryRequest request) =>
            await MakeSecureRequestAsync<BinanceWithdrawHistory>(HttpMethod.Get, "wapi/v3/withdrawHistory.html", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceDepositAddress>> GetDepositAddress(BinanceDepositAddressRequest request) =>
            await MakeSecureRequestAsync<BinanceDepositAddress>(HttpMethod.Get, "wapi/v3/depositAddress.html", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceWithdrawFee>> GetWithdrawFee(BinanceWithdrawFeeRequest request) =>
            await MakeSecureRequestAsync<BinanceWithdrawFee>(HttpMethod.Get, "wapi/v3/withdrawFee.html", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceAccountStatus>> GetAccountStatus(BinanceAccountStatusRequest request) =>
            await MakeSecureRequestAsync<BinanceAccountStatus>(HttpMethod.Get, "wapi/v3/accountStatus.html", request.BuildRequestString());
        #endregion User data Rest API

        #region Trade Rest API
        public async Task<BinanceResponse<BinanceOrder>> NewOrder(BinanceNewOrderRequest request) =>
            await MakeSecureRequestAsync<BinanceOrder>(HttpMethod.Post, "api/v3/order", request.BuildRequestString());

        public async Task<BinanceResponse<object>> TestNewOrder(BinanceNewOrderRequest request) =>
            await MakeSecureRequestAsync<object>(HttpMethod.Post, "api/v3/order/test", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceOrder>> QueryOrder(BinanceQueryOrderRequest request) =>
            await MakeSecureRequestAsync<BinanceOrder>(HttpMethod.Get, "api/v3/order", request.BuildRequestString());

        public async Task<BinanceResponse<BinanceCancelledOrder>> CancelOrder(BinanceCancelOrderRequest request) =>
            await MakeSecureRequestAsync<BinanceCancelledOrder>(HttpMethod.Delete, "api/v3/order", request.BuildRequestString());
        #endregion Trade Rest API

        #region Web Socket Streams      
        //
        public async Task OpenAggregateTradeStreamAsync(string symbol) => 
            await OpenStreamAsync<BinanceEventAggregatedTrade>(new BinanceAggregateTradeStreamNameInfo(symbol));

        public async Task CloseAggregateTradeStreamAsync(string symbol) => 
            await CloseStreamAsync(new BinanceAggregateTradeStreamNameInfo(symbol));

        //
        public async Task OpenTradeStreamAsync(string symbol) => 
            await OpenStreamAsync<BinanceEventTrade>(new BinanceAggregateTradeStreamNameInfo(symbol));

        public async Task CloseTradeStreamAsync(string symbol) => 
            await CloseStreamAsync(new BinanceAggregateTradeStreamNameInfo(symbol));

        //
        public async Task OpenCandlestickStreamAsync(string symbol, BinanceChartInterval interval) => 
            await OpenStreamAsync<BinanceEventKline>(new BinanceCandlestickStreamNameInfo(symbol, interval));

        public async Task CloseCandlestickStreamAsync(string symbol, BinanceChartInterval interval) => 
            await CloseStreamAsync(new BinanceCandlestickStreamNameInfo(symbol, interval));

        //
        public async Task OpenTicker24hrStreamAsync(string symbol) => 
            await OpenStreamAsync<BinanceEventTicker>(new BinanceTicker24hrStreamNameInfo(symbol));

        public async Task CloseTicker24hrStreamAsync(string symbol) => 
            await CloseStreamAsync(new BinanceTicker24hrStreamNameInfo(symbol));

        //
        public async Task OpenAllMarketTickersStream() => 
            await OpenStreamAsync<BinanceEventAllMarketTickers>(new BinanceAllTickersStreamNameInfo());

        public async Task CloseAllMarketTickersStream() => 
            await CloseStreamAsync(new BinanceAllTickersStreamNameInfo());

        //
        public async Task OpenPartialBookDepthStream(string symbol, int levels) => 
            await OpenStreamAsync<BinanceEventPartialBookDepth>(new BinancePartialBookDepthStreamNameInfo(symbol, levels));

        public async Task ClosePartialBookDepthStream(string symbol, int levels) => 
            await CloseStreamAsync(new BinancePartialBookDepthStreamNameInfo(symbol, levels));

        //
        public async Task OpenDiffDepthStream(string symbol) => 
            await OpenStreamAsync<BinanceEventDiffDepth>(new BinanceDiffDepthStreamNameInfo(symbol));

        public async Task CloseDiffDepthStream(string symbol) => 
            await CloseStreamAsync(new BinanceDiffDepthStreamNameInfo(symbol));

        //
        public async Task OpenAccountStream(string listenKey) => 
            await OpenStreamAsync<BinanceEventUserData>(new BinanceEmptyStreamNameInfo(listenKey));

        public async Task CloseAccountStream(string listenKey) => 
            await CloseStreamAsync(new BinanceEmptyStreamNameInfo(listenKey));

        //
        public async Task<string> OpenCombinedStream(params BinanceStreamNameInfo[] infoItems)
        {
            IBinanceStream stream;

            lock (this.streamsCacheLocker)
            {
                string streamName = BinanceCombinedStream.CombineStreamName(infoItems);
                if (this.streamsCache.ContainsKey(streamName))
                    return streamName;

                var combinedStream = new BinanceCombinedStream(this.socketBaseEndpoint, streamName, infoItems);

                combinedStream.Opened += this.Stream_Opened;
                combinedStream.Closed += this.Stream_Closed;
                combinedStream.Error += this.Stream_Error;
                combinedStream.EventReceived += this.Stream_EventReceived;
                combinedStream.Initialize();

                stream = combinedStream;

                this.streamsCache.Add(streamName, combinedStream);
            }

            await stream.OpenAsync();

            return stream.Name;
        }

        public async Task CloseCombinedStream(string streamName) =>
            await CloseStreamAsync(new BinanceEmptyStreamNameInfo(streamName));
        #endregion Web Socket Streams

        #region Utilities
        public static DateTime ConvertTime(long unixMiliseconds)
        {
            long ticks = UNIX_START_TIME_TICKS + (unixMiliseconds * TimeSpan.TicksPerMillisecond);
            return new DateTime(ticks, DateTimeKind.Utc);
        }

        public static long ConvertTime(DateTime dateTime) => (dateTime.Ticks - UNIX_START_TIME_TICKS) / TimeSpan.TicksPerMillisecond;

        public void ForbidAllRequests(int miliseconds)
        {
            Task task = null;

            lock(this.forbidLocker)
            {
                if (this.forbidAllRequests)
                    throw new InvalidOperationException($"Requests are already forbidden. Approximate time to relese - {CalculateRemainingForbiddenTime()}");

                this.forbidAllRequests = true;
                this.forbidMiliseconds = miliseconds;
                this.forbiddenStartTimeUtc = DateTime.UtcNow;
                this.forbidCancellationTokenSource = new CancellationTokenSource();

                task = Task.Delay(this.forbidMiliseconds, this.forbidCancellationTokenSource.Token);
            }

            task.ContinueWith((t) => 
            {
                lock (this.forbidLocker)
                {
                    this.forbidAllRequests = false;
                    this.forbidMiliseconds = default;
                    this.forbiddenStartTimeUtc = default;
                    this.forbidCancellationTokenSource = null;
                }
            });
        }

        public void ReleaseAllRequests() => this.forbidCancellationTokenSource?.Cancel();
        #endregion

        #region Misc
        private async Task<BinanceResponse<T>> MakeRequestAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            BinanceResponse<T> result = new BinanceResponse<T>();

            if (this.forbidAllRequests)
            {
                result.ErrorCode = BinanceErrors.REQUEST_FORBIDDEN_MANUALLY;
                result.ErrorMessage = $"All requests are forbidden manual. Approximate time to release - {CalculateRemainingForbiddenTime()}";

                return result;
            }

            var response = await this.httpClient.SendAsync(httpRequestMessage);

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                result.Content = JsonConvert.DeserializeObject<T>(json);
            else
                result = JsonConvert.DeserializeObject<BinanceResponse<T>>(json);

            return result;
        }

        private async Task<BinanceResponse<T>> MakeRequestAsync<T>(HttpMethod httpMethod, string endpoint, string parameters = "")
        {
            string requestUri = string.IsNullOrEmpty(parameters) ? endpoint : $"{endpoint}?{parameters}";

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        private async Task<BinanceResponse<T>> MakeSecureRequestAsync<T>(HttpMethod httpMethod, string endpoint, string parameters, bool signed = true)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Method = httpMethod
            };

            httpRequestMessage.Headers.Add("X-MBX-APIKEY", this.apiKey);

            if (signed)
            {
                string signature = EncryptData(parameters);

                httpRequestMessage.RequestUri = new Uri(this.httpClient.BaseAddress, $"{endpoint}?{parameters}&signature={signature}");
            }
            else
                httpRequestMessage.RequestUri = new Uri(this.httpClient.BaseAddress, string.IsNullOrEmpty(parameters) ? endpoint : $"{endpoint}?{parameters}");

            return await MakeRequestAsync<T>(httpRequestMessage);
        }

        private async Task OpenStreamAsync<T>(BinanceStreamNameInfo info)
            where T : BinanceEvent
        {
            IBinanceStream stream;

            string streamName = info.BuildStreamFullName();

            lock (this.streamsCacheLocker)
            {
                if (this.streamsCache.ContainsKey(streamName))
                    throw new ArgumentException($"Stream with name \"{streamName}\" already exist");

                var tStream = new BinanceStream<T>(this.socketBaseEndpoint, streamName);
                tStream.Opened += this.Stream_Opened;
                tStream.Closed += this.Stream_Closed;
                tStream.Error += this.Stream_Error;
                tStream.EventReceived += this.Stream_EventReceived;
                tStream.Initialize();

                stream = tStream;

                this.streamsCache.Add(streamName, stream);
            }

            await stream.OpenAsync();
        }

        private async Task CloseStreamAsync(BinanceStreamNameInfo info)
        {
            IBinanceStream stream;

            string streamName = info.BuildStreamFullName();

            lock (this.streamsCacheLocker)
            {
                if (!this.streamsCache.TryGetValue(streamName, out stream))
                    throw new ArgumentException($"Stream with name \"{streamName}\" not found");

                this.streamsCache.Remove(streamName);
            }

            await stream.CloseAsync();
        }

        private void Stream_Opened(string streamName, BinanceEventArgs e) => this.StreamOpened?.Invoke(streamName, e);

        private void Stream_Closed(string streamName, BinanceEventArgs e)
        {
            lock (this.streamsCacheLocker)
                this.streamsCache.Remove(streamName);

            this.StreamClosed?.Invoke(streamName, e);
        }

        private void Stream_Error(string streamName, BinanceEventArgs e) => this.StreamError?.Invoke(streamName, e);

        private void Stream_EventReceived(string streamName, BinanceEvent binanceEvent) => this.EventReceived?.Invoke(streamName, binanceEvent);

        private string EncryptData(string data)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.secretKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(dataBytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }

        private TimeSpan CalculateRemainingForbiddenTime()
        {
            if (this.forbidMiliseconds == default || this.forbiddenStartTimeUtc == default)
                return TimeSpan.Zero;

            DateTime releaseTime = this.forbiddenStartTimeUtc.AddMilliseconds(this.forbidMiliseconds);

            TimeSpan remainingTime = releaseTime - DateTime.UtcNow;

            return remainingTime;
        }
        #endregion Misc
    }

    public delegate void BinanceStreamEventHandler(string streamName, BinanceEventArgs e);
    public delegate void BinanceStreamEventHandler<T>(string streamName, T binanceEvent);
}