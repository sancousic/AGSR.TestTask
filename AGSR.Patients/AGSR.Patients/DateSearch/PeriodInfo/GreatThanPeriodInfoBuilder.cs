
using AGSR.Patients.Constants;

namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public class GreatThanPeriodInfoBuilder : IPeriodInfoBuilder
    {
        public IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel)
        {
            var info = new PeriodInfo(GetStartDate(dateSearchModel), null, false);

            return new[] { info };
        }

        private static DateTimeOffset? GetStartDate(DateSearchModel dateSearchModel)
            => dateSearchModel.Date.Value.AddMilliseconds(1);
    }
}
