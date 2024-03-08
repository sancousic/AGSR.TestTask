using AGSR.Patients.DateSearch.PeriodInfo;
using LinqKit;

namespace AGSR.Patients.Services
{
    public interface IPredicateBuilder<T>
    {
        ExpressionStarter<T> BuildPredicate(IEnumerable<PeriodInfo> periodInfos);
    }
}