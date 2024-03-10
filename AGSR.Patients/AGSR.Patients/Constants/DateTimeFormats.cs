namespace AGSR.Patients.Constants
{
    public static class DateTimeFormats
    {
        public const string YearOnlyFormat = "yyyy";
        public const string MonthFormat = "yyyy-MM";
        public const string DayFormat = "yyyy-MM-dd";
        public const string HourFormat = "yyyy-MM-ddTHH";
        public const string MinuteFormat = "yyyy-MM-ddTHH:mm";
        public const string SecondFormat = "yyyy-MM-ddTHH:mm:ss";
        public const string MilisecondFormat = "yyyy-MM-ddTHH:mm:ss.ssss";

        public static string[] SupportedFormats = new[] { MilisecondFormat, SecondFormat, MinuteFormat, HourFormat, DayFormat, MonthFormat, YearOnlyFormat };
        public static string[] AllSupportedFormats = SupportedFormats.Concat(SupportedFormats.Select(x => x + "K")).ToArray();
    }
}
