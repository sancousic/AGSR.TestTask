﻿using System.Globalization;
using static AGSR.Patients.Constants.DateTimeFormats;

namespace AGSR.Patients.Services.Implementations;

public class DateTimeOffsetParser : IDateTimeOffsetParser
{
    public bool TryParseExactWithFormat(string date, CultureInfo? cultureInfo, DateTimeStyles style, out string? parsedFormat,
        out DateTimeOffset? dateTimeOffset)
    {
        parsedFormat = null;
        dateTimeOffset = null;

        foreach (var format in DateSupportedFormats)
        {
            if (DateTimeOffset.TryParseExact(date, format, cultureInfo, style, out var dateTime))
            {
                parsedFormat = format;
                dateTimeOffset = dateTime;

                return true;
            }
        }

        return false;
    }
}