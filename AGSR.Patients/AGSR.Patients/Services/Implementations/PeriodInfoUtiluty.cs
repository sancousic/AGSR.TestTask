using AGSR.Patients.Constants;
using AGSR.Patients.DateSearch;
using AGSR.Patients.DateSearch.PeriodInfo;

namespace AGSR.Patients.Services.Implementations
{
    public class PeriodInfoUtiluty : IPeriodInfoUtiluty
    {
        protected readonly IPeriodInfoFactory _periodInfoFactory;

        public PeriodInfoUtiluty(IPeriodInfoFactory periodInfoFactory)
        {
            _periodInfoFactory = periodInfoFactory;
        }

        public IEnumerable<PeriodInfo> GetPeriodInfos(IEnumerable<DateSearchModel> dates)
            => dates.Select(x => _periodInfoFactory.GetBuilder(x.Prefix).Build(x)).SelectMany(x => x);
    }
}
