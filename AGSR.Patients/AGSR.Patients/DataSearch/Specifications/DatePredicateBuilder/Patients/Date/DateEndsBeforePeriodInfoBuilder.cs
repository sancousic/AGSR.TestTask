using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Specifications.DatePredicateBuilder.Patients.Date
{
    public class DateEndsBeforePeriodInfoBuilder : SpecificationBase<Patient, PeriodInfo>
    {
        public DateEndsBeforePeriodInfoBuilder(PeriodInfo data) : base(data)
        {
        }

        public override Expression<Func<Patient, bool>> ToExpressions() => patient =>
            patient.BirthDate < Data.StartDate.Date;
    }
}
