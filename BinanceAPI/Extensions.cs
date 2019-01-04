using System;
using System.Runtime.Serialization;

namespace BinanceAPI
{
    public static class Extensions
    {
        public static string Format(this Enum value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes?[0] is EnumMemberAttribute enumMemberAttribute)
                return enumMemberAttribute.Value;
            else
                return value.ToString();
        }
    }
}
