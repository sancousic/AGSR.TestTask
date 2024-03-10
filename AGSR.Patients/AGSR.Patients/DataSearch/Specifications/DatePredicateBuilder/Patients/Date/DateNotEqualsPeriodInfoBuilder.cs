using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.DatePredicateBuilder.Patients.Date
{
    public class DateNotEqualsPeriodInfoBuilder : SpecificationBase<Patient, PeriodInfo>
    {
        public DateNotEqualsPeriodInfoBuilder(PeriodInfo data) : base(data)
        {
        }

        public override Expression<Func<Patient, bool>> ToExpressions()
            => patient => Data.StartDate.Date > patient.BirthDate
                          || Data.EndDate.Date <= patient.BirthDate;
    }
}
