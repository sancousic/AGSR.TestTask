using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.Patients.Date;

public class DateApproximatelySamePredicateBuilder : SpecificationBase<Patient, PeriodInfo>
{
    private const double ApproximatePercent = 0.1;

    public DateApproximatelySamePredicateBuilder(PeriodInfo data)
        : base(data)
    {
    }

    public override Expression<Func<Patient, bool>> ToExpressions()
    {
        var approximateRange = GetApproximateRange(SearchData.StartDate.Date);

        return patient => SearchData.StartDate.Date.AddTicks(-approximateRange) <= patient.BirthDate
                          && patient.BirthDate < SearchData.EndDate.Date.AddTicks(approximateRange);
    }

    private static long GetApproximateRange(DateTimeOffset date)
    {
        return ((DateTimeOffset.UtcNow - date) * ApproximatePercent).Ticks;
    }
}