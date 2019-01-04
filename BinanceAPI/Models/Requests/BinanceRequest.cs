using System;
using System.Globalization;

namespace BinanceAPI.Models
{
    public abstract class BinanceRequest
    {
        public long Timestamp { get; set; }

        public long? RecvWindow { get; set; }

        protected static CultureInfo EnUsCulture { get; private set; }

        static BinanceRequest() => EnUsCulture = new CultureInfo("en-US");

        internal virtual string BuildRequestString() => 
            $"timestamp={this.Timestamp}" +
            $"{TryGetRequestParameter(this.RecvWindow, "recvWindow")}";

        protected internal static string TryGetRequestParameter(object parameter, string parameterName) =>
            parameter == null ? string.Empty : $"&{parameterName}={parameter}";

        protected internal static string TryGetRequestParameterForDecimal(decimal? parameter, string parameterName) =>
            parameter == null ? string.Empty : $"&{parameterName}={parameter.Value.ToString(EnUsCulture)}";

        protected internal static string TryGetRequestParameterForEnum(object parameter, string parameterName) =>
            parameter == null ? string.Empty : $"&{parameterName}={(parameter as Enum).Format()}";
    }
}