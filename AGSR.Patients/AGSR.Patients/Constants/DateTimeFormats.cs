namespace AGSR.Patients.Constants;

public static class DateTimeFormats
{
    private static readonly string[] SupportedFormatsWithoutZone =
        { MillisecondFormat, SecondFormat, MinuteFormat, HourFormat, DayFormat, MonthFormat, YearOnlyFormat };

    public const string YearOnlyFormat = "yyyy";
    public const string MonthFormat = "yyyy-MM";
    public const string DayFormat = "yyyy-MM-dd";
    public const string HourFormat = "yyyy-MM-ddTHH";
    public const string MinuteFormat = "yyyy-MM-ddTHH:mm";
    public const string SecondFormat = "yyyy-MM-ddTHH:mm:ss";
    public const string MillisecondFormat = "yyyy-MM-ddTHH:mm:ss.ssss";

    public static readonly string[] DateSupportedFormats = SupportedFormatsWithoutZone
        .Concat(SupportedFormatsWithoutZone.Select(x => x + "K")).ToArray();
}