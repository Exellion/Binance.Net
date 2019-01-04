using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace BinanceAPI.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceEventType
    {
        [EnumMember(Value = "aggTrade")]
        AggregateTrade,
        [EnumMember(Value = "trade")]
        Trade,
        [EnumMember(Value = "kline")]
        Kline,
        [EnumMember(Value = "24hrTicker")]
        Ticker24hr,
        AllMarketTickers,
        PartialBookDepth,
        [EnumMember(Value = "depthUpdate")]
        DifferenceBoolDepth,
        [EnumMember(Value = "outboundAccountInfo")]
        AccountUpdate,
        [EnumMember(Value = "executionReport")]
        OrderUpdate
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceChartInterval
    {
        [EnumMember(Value = "1m")]
        m1,
        [EnumMember(Value = "3m")]
        m3,
        [EnumMember(Value = "5m")]
        m5,
        [EnumMember(Value = "15m")]
        m15,
        [EnumMember(Value = "30m")]
        m30,
        [EnumMember(Value = "1h")]
        h1,
        [EnumMember(Value = "2h")]
        h2,
        [EnumMember(Value = "4h")]
        h4,
        [EnumMember(Value = "6h")]
        h6,
        [EnumMember(Value = "8h")]
        h8,
        [EnumMember(Value = "12h")]
        h12,
        [EnumMember(Value = "1d")]
        d1,
        [EnumMember(Value = "3d")]
        d3,
        [EnumMember(Value = "1w")]
        w1,
        [EnumMember(Value = "1M")]
        M1
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceSymbolStatus
    {
        [EnumMember(Value = "PRE_TRADING")]
        PreTrading,
        [EnumMember(Value = "TRADING")]
        Trading,
        [EnumMember(Value = "POST_TRADING")]
        PostTrading,
        [EnumMember(Value = "END_OF_DAY")]
        EndOfDay,
        [EnumMember(Value = "HALT")]
        Halt,
        [EnumMember(Value = "AUCTION_MATCH")]
        AuctionMatch,
        [EnumMember(Value = "BREAK")]
        Break
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceSymbolType
    {
        [EnumMember(Value = "SPOT")]
        Spot
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceOrderStatus
    {
        [EnumMember(Value = "NEW")]
        New,
        [EnumMember(Value = "PARTIALLY_FILLED")]
        PartiallyFilled,
        [EnumMember(Value = "FILLED")]
        Filled,
        [EnumMember(Value = "CANCELED")]
        Canceled,
        [EnumMember(Value = "PENDING_CANCEL")]
        PendingCanceled,
        [EnumMember(Value = "REJECTED")]
        Rejected,
        [EnumMember(Value = "EXPIRED")]
        Expired
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceExecutionType
    {
        [EnumMember(Value = "NEW")]
        New,        
        [EnumMember(Value = "CANCELED")]
        Canceled,
        [EnumMember(Value = "REJECTED")]
        Rejected,
        [EnumMember(Value = "TRADE")]
        Trade,
        [EnumMember(Value = "EXPIRED")]
        Expired
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceOrderType
    {
        [EnumMember(Value = "LIMIT")]
        Limit,
        [EnumMember(Value = "MARKET")]
        Market,
        [EnumMember(Value = "STOP_LOSS")]
        StopLoss,
        [EnumMember(Value = "STOP_LOSS_LIMIT")]
        StopLossLimit,
        [EnumMember(Value = "TAKE_PROFIT")]
        TakeProfit,
        [EnumMember(Value = "TAKE_PROFIT_LIMIT")]
        TakeProfitLimit,
        [EnumMember(Value = "LIMIT_MAKER")]
        LimitMaker
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceOrderResponseType
    {
        [EnumMember(Value = "ACK")]
        Ack,
        [EnumMember(Value = "RESULT")]
        Result,
        [EnumMember(Value = "FULL")]
        Full
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceOrderSide
    {
        [EnumMember(Value = "BUY")]
        Buy,
        [EnumMember(Value = "SELL")]
        Sell
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceTimeInForce
    {
        [EnumMember(Value = "GTC")]
        GTC,
        [EnumMember(Value = "IOC")]
        IOC,
        [EnumMember(Value = "FOK")]
        FOK
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceRateLimiters
    {
        [EnumMember(Value = "REQUESTS")]
        Requests,
        [EnumMember(Value = "ORDERS")]
        Orders,
        [EnumMember(Value = "REQUEST_WEIGHT")]
        RequestWeight
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BinanceRateLimitIntervals
    {
        [EnumMember(Value = "SECOND")]
        Second,
        [EnumMember(Value = "MINUTE")]
        Minute,
        [EnumMember(Value = "DAY")]
        Day
    }

    public enum BinanceDepositStatus
    {
        [EnumMember(Value = "0")]
        Pending = 0,
        [EnumMember(Value = "1")]
        Success = 1
    }

    public enum BinanceWithdrawStatus
    {
        [EnumMember(Value = "0")]
        EmailSent = 0,
        [EnumMember(Value = "1")]
        Cancelled = 1,
        [EnumMember(Value = "2")]
        AwaitingApproval = 2,
        [EnumMember(Value = "3")]
        Rejected = 3,
        [EnumMember(Value = "4")]
        Processing = 4,
        [EnumMember(Value = "5")]
        Failure = 5,
        [EnumMember(Value = "6")]
        Completed = 6 
    }

    public enum BinanceSystemStatusEnum
    {
        [EnumMember(Value = "0")]
        Normal = 0,
        [EnumMember(Value = "1")]
        Maintenance = 1
    }
}