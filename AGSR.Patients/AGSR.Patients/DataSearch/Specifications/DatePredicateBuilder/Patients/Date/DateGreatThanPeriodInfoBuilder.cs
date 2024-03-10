using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.DatePredicateBuilder.Patients.Date;

public class DateGreatThanPeriodInfoBuilder : SpecificationBase<Patient, PeriodInfo>
{
    public DateGreatThanPeriodInfoBuilder(PeriodInfo data) : base(data)
    {
    }

    public override Expression<Func<Patient, bool>> ToExpressions()
        => patient => Data.EndDate.Date > patient.BirthDate;
}