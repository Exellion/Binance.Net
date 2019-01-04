namespace BinanceAPI
{
    public static class BinanceErrors
    {
        // 10xx - General Server or Network issues
        public const int UNKNOWN = -1000;
        public const int DISCONNECTED = -1001;
        public const int UNAUTHORIZED = -1002;
        public const int TOO_MANY_REQUESTS = -1003;
        public const int UNEXPECTED_RESP = -1006;
        public const int TIMEOUT = -1007;
        public const int ERROR_MSG_RECEIVED = -1010;
        public const int INVALID_MESSAGE = -1013;
        public const int UNKNOWN_ORDER_COMPOSITION = -1014;
        public const int TOO_MANY_ORDERS = -1015;
        public const int SERVICE_SHUTTING_DOWN = -1016;
        public const int UNSUPPORTED_OPERATION = -1020;
        public const int INVALID_TIMESTAMP = -1021;
        public const int INVALID_SIGNATURE = -1022;

        // 11xx - Request issues
        public const int ILLEGAL_CHARS = -1100;
        public const int TOO_MANY_PARAMETERS = -1101;
        public const int MANDATORY_PARAM_EMPTY_OR_MALFORMED = -1102;
        public const int UNKNOWN_PARAM = -1103;
        public const int UNREAD_PARAMETERS = -1104;
        public const int PARAM_EMPTY = -1105;
        public const int PARAM_NOT_REQUIRED = -1106;
        public const int NO_DEPTH = -1112;
        public const int TIF_NOT_REQUIRED = -1114;
        public const int INVALID_TIF = -1115;
        public const int INVALID_ORDER_TYPE = -1116;
        public const int INVALID_SIDE = -1117;
        public const int EMPTY_NEW_CL_ORD_ID = -1118;
        public const int EMPTY_ORG_CL_ORD_ID = -1119;
        public const int BAD_INTERVAL = -1120;
        public const int BAD_SYMBOL = -1121;
        public const int INVALID_LISTEN_KEY = -1125;
        public const int MORE_THAN_XX_HOURS = -1127;
        public const int OPTIONAL_PARAMS_BAD_COMBO = -1128;
        public const int INVALID_PARAMETER = -1130;

        public const int REQUEST_FORBIDDEN_MANUALLY = -1199;

        // 20xx - Processing Issues
        public const int BAD_API_ID = -2008;
        public const int DUPLICATE_API_KEY_DESC = -2009;
        public const int NEW_ORDER_REJECTED = -2010;
        public const int CANCEL_REJECTED = -2011;
        public const int CANCEL_ALL_FAIL = -2012;
        public const int NO_SUCH_ORDER = -2013;
        public const int BAD_API_KEY_FMT = -2014;
        public const int REJECTED_MBX_KEY = -2015;
    }
}