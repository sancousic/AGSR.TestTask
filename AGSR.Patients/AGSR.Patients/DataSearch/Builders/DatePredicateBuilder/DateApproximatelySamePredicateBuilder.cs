using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders.DatePredicateBuilder
{
    public class DateApproximatelySamePredicateBuilder<TEntity> : BasePredicateBuilder<TEntity, PeriodInfo>
        where TEntity: class, IEntity
    {
        private const double ApproximatePercent = 0.1;

        public DateApproximatelySamePredicateBuilder(Func<TEntity, PeriodInfo> getDataFunc)
            : base(getDataFunc)
        {
        }

        public override Func<TEntity, bool> BuildPredicate(PeriodInfo periodInfo)
        {
            return entity =>
            {
                var data = GetDataFunc(entity);
                var approximateRange = GetApproximateRange(periodInfo.StartDate.Date);

                return periodInfo.StartDate.Date.AddTicks(approximateRange) < data.EndDate.Date
                       && data.EndDate.Date < periodInfo.EndDate.Date.AddTicks(approximateRange);
            };
        }

        private static long GetApproximateRange(DateTimeOffset date)
        {
            return ((DateTimeOffset.UtcNow - date) * ApproximatePercent).Ticks;
        }
    }
}
