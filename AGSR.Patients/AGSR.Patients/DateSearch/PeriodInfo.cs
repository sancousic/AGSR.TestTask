namespace AGSR.Patients.DateSearch.PeriodInfo
{
    public record PeriodInfo(DateTimeOffset? StartDate, DateTimeOffset? EndDate, bool IsExlude = false);
}
