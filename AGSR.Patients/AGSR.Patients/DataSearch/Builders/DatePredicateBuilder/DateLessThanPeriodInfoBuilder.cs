using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder;

public class DateLessThanPeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
    where TEntity: class, IEntity
{
    public DateLessThanPeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
        : base(getDataFunc)
    {
    }

    public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
    {
        return entity =>
        {
            var dataStart = GetDataFunc(entity).StartDate.Date;
            var periodStart = periodInfo.StartDate.Date;

            return dataStart < periodStart;
        };
    }
}