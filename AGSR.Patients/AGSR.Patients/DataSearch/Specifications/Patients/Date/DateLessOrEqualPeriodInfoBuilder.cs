using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.Patients.Date;

public class DateLessOrEqualPeriodInfoBuilder : SpecificationBase<Patient, PeriodInfo>
{
    public DateLessOrEqualPeriodInfoBuilder(PeriodInfo data)
        : base(data)
    {
    }

    public override Expression<Func<Patient, bool>> ToExpressions() =>
        patient => patient.BirthDate <= SearchData.EndDate.Date;
}