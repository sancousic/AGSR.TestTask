using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders;

public abstract class BasePredicateBuilder<TEntity, TCompareType>
    : IPredicateBuilder<TEntity, TCompareType>
    where TEntity: class, IEntity
{
    protected Func<TEntity, TCompareType> GetDataFunc { get; }

    protected BasePredicateBuilder(Func<TEntity, TCompareType> getDataFunc)
    {
        GetDataFunc = getDataFunc;
    }

    public abstract Func<TEntity, bool> BuildPredicate(TCompareType periodInfo);
}