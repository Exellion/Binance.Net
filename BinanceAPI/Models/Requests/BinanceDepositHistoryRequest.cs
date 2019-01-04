namespace BinanceAPI.Models
{
    public class BinanceDepositHistoryRequest : BinanceRequest
    {
        public string Asset { get; set; }

        public BinanceDepositStatus? Status { get; set; }

        public long? StartTime { get; set; }

        public long? EndTime { get; set; }

        internal override string BuildRequestString() =>
            $"{base.BuildRequestString()}" +
            $"{TryGetRequestParameter(this.Asset, "asset")}" +
            $"{TryGetRequestParameterForEnum(this.Status, "status")}" +
            $"{TryGetRequestParameter(this.StartTime, "startTime")}" +
            $"{TryGetRequestParameter(this.EndTime, "endTime")}";
    }
}