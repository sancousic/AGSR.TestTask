using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder
{
    public class DateGreatOrEqualPeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
        where TEntity: class, IEntity
    {
        public DateGreatOrEqualPeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
            : base(getDataFunc)
        {
        }

        public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
        {
            return entity =>
            {
                var dataStart = GetDataFunc(entity).StartDate.Date;
                var periodStart = periodInfo.StartDate.Date;

                return  periodStart >= dataStart;
            };
        }
    }
}
