using System.Globalization;

namespace AGSR.Patients.Services;

public interface IDateTimeOffsetParser
{
    bool TryParseExactWithFormat(
        string date, CultureInfo? cultureInfo,
        DateTimeStyles style, out string? parsedFormat,
        out DateTimeOffset? dateTimeOffset);
}