using AGSR.Patients.DateSearch.PeriodInfo;

namespace AGSR.Patients.Services
{
    public interface IPeriodInfoFactory
    {
        IPeriodInfoBuilder GetBuilder(string prefix);
    }
}