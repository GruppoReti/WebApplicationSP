using System;
using System.Xml;

namespace Kentor.AuthServices.Internal
{
    static class DateTimeExtensions
    {
        public static string ToSaml2DateTimeString(this DateTime dateTime)
        {
            return XmlConvert.ToString(dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond)),
                XmlDateTimeSerializationMode.Utc);
        }
    }
}
