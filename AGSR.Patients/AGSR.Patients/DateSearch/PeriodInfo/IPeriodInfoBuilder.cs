namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public interface IPeriodInfoBuilder
    {
        IEnumerable<PeriodInfo> Build(DateSearchModel dateSearchModel);
    }
}
