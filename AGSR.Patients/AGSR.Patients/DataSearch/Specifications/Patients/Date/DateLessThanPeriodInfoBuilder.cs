using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.Patients.Date;

public class DateLessThanPeriodInfoBuilder : SpecificationBase<Patient, PeriodInfo>
{
    public DateLessThanPeriodInfoBuilder(PeriodInfo searchData)
        : base(searchData)
    {
    }

    public override Expression<Func<Patient, bool>> ToExpressions() =>
        patient => patient.BirthDate < SearchData.StartDate.Date;
}