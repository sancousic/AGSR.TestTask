using AGSR.Patients.DataSearch.Builders;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DateSearch.Builders
{
    public class DateEqualsPeriodInfoBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
        where TEntity: class, IEntity
    {
        public DateEqualsPeriodInfoBuilder(Func<TEntity, PeriodInfo> getDataFunc)
            : base(getDataFunc)
        {
        }

        public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
        {
            return entity =>
            {
                var data = GetDataFunc(entity);

                return periodInfo.StartDate.Date <= data.EndDate.Date
                       && data.EndDate.Date < periodInfo.EndDate.Date;
            };
        }
    }
}
