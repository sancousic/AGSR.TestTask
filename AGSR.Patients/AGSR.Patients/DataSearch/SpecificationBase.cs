using System.Linq.Expressions;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DataSearch;

public abstract class SpecificationBase<TEntity, TSearchData> : ISpecification<TEntity> where TEntity: class, IEntity
{
    protected TSearchData SearchData { get; }

    public SpecificationBase(TSearchData searchData)
    {
        SearchData = searchData;
    }

    public abstract Expression<Func<TEntity, bool>> ToExpressions();
}