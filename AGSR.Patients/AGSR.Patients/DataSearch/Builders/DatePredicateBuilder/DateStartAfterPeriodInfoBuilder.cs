using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder
{
    public class DateStartAfterPeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
        where TEntity: class, IEntity

    {
        public DateStartAfterPeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
            : base(getDataFunc)
        {
        }

        public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
        {
            return entity =>
            {
                var dataStart = GetDataFunc(entity).StartDate.Date;
                var periodEnd = periodInfo.EndDate.Date;

                return dataStart > periodEnd;
            };
        }
    }
}
