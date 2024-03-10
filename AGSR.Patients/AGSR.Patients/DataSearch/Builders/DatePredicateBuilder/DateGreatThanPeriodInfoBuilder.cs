using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder;

public class DateGreatThanPeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
    where TEntity: class, IEntity
{
    public DateGreatThanPeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
        : base(getDataFunc)
    {
    }

    public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
    {
        return entity =>
        {
            var dataStart = GetDataFunc(entity).StartDate.Date;
            var periodEnd = periodInfo.EndDate.Date;

            return  periodEnd > dataStart;
        };
    }
}