using System.Globalization;
using static AGSR.Patients.Constants.DateTimeFormats;

namespace AGSR.Patients.Extensions
{
    public static class DateTimeOffsetX
    {
        public static bool TryParseExactWithFormat(this DateTimeOffset dateTime, string date, CultureInfo? cultureInfo, DateTimeStyles style, out string? parsedFormat, out DateTimeOffset? dateTimeOffset)
        {
            parsedFormat = null;
            dateTimeOffset = null;

            foreach (var format in DateSupportedFormats)
            {
                if(DateTimeOffset.TryParseExact(date, format, cultureInfo, style, out dateTime))
                {
                    parsedFormat = format;
                    dateTimeOffset = dateTime;
                    
                    return true;
                }
            }

            return false;
        }
    }
}
