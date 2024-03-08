using AGSR.Patients.Constants;
using AGSR.Patients.DateSearch.PeriodInfo;

namespace AGSR.Patients.Services.Implementations
{
    public class PeriodInfoFactory : IPeriodInfoFactory
    {
        public IPeriodInfoBuilder GetBuilder(string prefix)
            => prefix switch
            {
                Prefixes.Equals => new EqualsPeriodInfoBuilder(),
                Prefixes.NotEquals => new EqualsPeriodInfoBuilder(),
                Prefixes.GreaterThan => new GreatThanPeriodInfoBuilder(),
                Prefixes.LessThan => new LessThanPeriodInfoBuilder(),
                Prefixes.GreaterOrEqueal => new GreatOrEquealPeriodInfoBuilder(),
                Prefixes.LessOrEqual => new LessOrEqualPeriodInfoBuilder(),
                Prefixes.StartAfter => new StartAfterPeriodInfoBuilder(),
                Prefixes.EndsBefore => new EndsBeforePeriodInfoBuilder(),
                Prefixes.ApproximatelySame => new ApproximatelySamePeriodInfoBuilder(),
                _ => throw new NotSupportedException(),
            };
    }
}
