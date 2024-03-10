using AGSR.Patients.Constants;
using AGSR.Patients.DataSearch.Builders;
using AGSR.Patients.DataSearch.Builders.DatePredicateBuilder;
using AGSR.Patients.DateSearch;
using AGSR.Patients.DateSearch.Builders;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.Services.Implementations
{
    public class PeriodInfoFactory<T> : IPeriodInfoFactory<T>
        where T: class, IEntity
    {
        public PeriodInfoFactory(Func<T, PeriodInfo> getDataFunc)
        {
            GetDataFunc = getDataFunc;
        }

        private Func<T, PeriodInfo> GetDataFunc { get; }

        public IPredicateBuilder<T, PeriodInfo> GetBuilder(string prefix)
            => prefix switch
            {
                Prefixes.Equals => new DateEqualsPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.NotEquals => new DateEqualsPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.GreaterThan => new DateGreatThanPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.LessThan => new DateLessThanPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.GreaterOrEqueal => new DateGreatOrEqualPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.LessOrEqual => new DateLessOrEqualPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.StartAfter => new DateStartAfterPeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.EndsBefore => new DateEndsBeforePeriodInfoBuilder<T>(GetDataFunc),
                Prefixes.ApproximatelySame => new DateApproximatelySamePredicateBuilder<T>(GetDataFunc),
                _ => throw new NotSupportedException(),
            };
    }
}
