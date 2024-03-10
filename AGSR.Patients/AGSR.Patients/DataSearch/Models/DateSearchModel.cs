using System.Globalization;
using AGSR.Patients.Constants;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Extensions;

namespace AGSR.Patients.DataSearch.Models;

public class DateSearchModel : DataSearchModel<PeriodInfo>
{
    private string? Format { get; set; }

    public DateSearchModel(string searchValue) : base(searchValue)
    {
    }

    public override void Init()
    {
        if (DateTimeOffset.Now.TryParseExactWithFormat(Search[2..], CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var format, out var date))
        {
            Format = format;
            Data = GetEndDate(date.Value);
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
            DateTimeFormats.MilisecondFormat => date.AddMilliseconds(1),
            _ => throw new NotSupportedException(),
        };

        endDate = endDate.AddMilliseconds(-1);

        return new PeriodInfo(new DateTimePoint(date, true), new DateTimePoint(endDate, true), true);
    }
}