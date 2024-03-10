using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch.Builders
{
    public interface IPredicateBuilder<in TEntity, TSearchModelType>
        where TEntity: class, IEntity
    {
        Func<TEntity, bool> BuildPredicate(TSearchModelType periodInfo);
    }
}
