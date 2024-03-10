namespace AGSR.Patients.DateSearch
{
    public record PeriodInfo(DateTimePoint? StartDate, DateTimePoint? EndDate, bool IsExclude = false);
}
