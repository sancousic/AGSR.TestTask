
namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public class LessOrEqualPeriodInfoBuilder : IPeriodInfoBuilder
    {
        public IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel)
        {
            var info = new PeriodInfo(null, GetEndDate(dateSearchModel), false);

            return new[] { info };
        }

        private static DateTimeOffset? GetEndDate(DateSearchModel dateSearchModel)
            => dateSearchModel.Date.Value.AddMilliseconds(1);
    }
}
