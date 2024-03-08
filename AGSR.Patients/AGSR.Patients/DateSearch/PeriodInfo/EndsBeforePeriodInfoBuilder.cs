
using AGSR.Patients.Constants;

namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public class EndsBeforePeriodInfoBuilder : IPeriodInfoBuilder
    {
        public IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel)
        {
            var info = new PeriodInfo(null, GetEndDate(dateSearchModel), false);

            return new[] { info };
        }

        private static DateTimeOffset? GetEndDate(DateSearchModel dateSearchModel)
            => dateSearchModel.Format switch
            {
                DateTimeFormats.YearOnlyFormat => dateSearchModel.Date.Value.AddYears(-1),
                DateTimeFormats.MonthFormat => dateSearchModel.Date.Value.AddMonths(-1),
                DateTimeFormats.DayFormat => dateSearchModel.Date.Value.AddDays(-1),
                DateTimeFormats.HourFormat => dateSearchModel.Date.Value.AddHours(-1),
                DateTimeFormats.MinuteFormat => dateSearchModel.Date.Value.AddMinutes(-1),
                DateTimeFormats.SecondFormat => dateSearchModel.Date.Value.AddSeconds(-1),
                DateTimeFormats.MilisecondFormat => dateSearchModel.Date.Value.AddMilliseconds(-1),
                _ => throw new NotSupportedException(),
            };
    }
}
