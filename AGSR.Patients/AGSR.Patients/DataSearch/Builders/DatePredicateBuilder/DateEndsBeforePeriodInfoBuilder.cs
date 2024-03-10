using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder
{
    public class DateEndsBeforePeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
        where TEntity: class, IEntity
    {
        public DateEndsBeforePeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
            : base(getDataFunc)
        {
        }

        public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
        {
            return entity =>
            {
                var dataEnd = GetDataFunc(entity).EndDate.Date;
                var startDate = periodInfo.StartDate.Date;

                return dataEnd < startDate;
            };
        }
    }
}
