using AGSR.Patients.DateSearch;
using AGSR.Patients.DateSearch.PeriodInfo;

namespace AGSR.Patients.Services
{
    public interface IPeriodInfoUtiluty
    {
        IEnumerable<PeriodInfo> GetPeriodInfos(IEnumerable<DateSearchModel> dates);
    }
}