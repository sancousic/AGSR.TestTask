using System.Globalization;
using AGSR.Patients.Constants;
using AGSR.Patients.DataSearch.Models;
using AGSR.Patients.DateSearch;

namespace AGSR.Patients.Services.Implementations;

public class DateSearchModelBuilder : RangeDataSearchModelBuilder<PeriodInfo>
{
    private readonly IDateTimeOffsetParser _parser;

    public DateSearchModelBuilder(IDateTimeOffsetParser parser)
    {
        _parser = parser;
    }

    private string? Format { get; set; }

    public override DataSearchModel<PeriodInfo> Build(string searchValue)
    {
        var prefix = GetPrefix(searchValue);
        var search = prefix == null ? searchValue : searchValue[2..];

        if (_parser.TryParseExactWithFormat(search, CultureInfo.CurrentCulture,
                DateTimeStyles.AssumeLocal, out var format, out var date))
        {
            Format = format;

            return new DataSearchModel<PeriodInfo>
            {
                Data = GetEndDate(date.Value),
                Prefix = prefix ?? Prefixes.EqualsPrefix,
            };
        }

        throw new ArgumentException();
    }

    private PeriodInfo GetEndDate(DateTimeOffset date)
    {
        var endDate = Format switch
        {
            DateTimeFormats.YearOnlyFormat => date.AddYears(1),
            DateTimeFormats.MonthFormat => date.AddMonths(1),
            DateTimeFormats.DayFormat => date.AddDays(1),
            DateTimeFormats.HourFormat => date.AddHours(1),
            DateTimeFormats.MinuteFormat => date.AddMinutes(1),
            DateTimeFormats.SecondFormat => date.AddSeconds(1),
            DateTimeFormats.MillisecondFormat => date.AddMilliseconds(1),
            _ => throw new NotSupportedException(),
        };

        return new PeriodInfo(new DateTimePoint(date, true), new DateTimePoint(endDate, true), true);
    }
}