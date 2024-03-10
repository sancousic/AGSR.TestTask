using System.Linq.Expressions;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DateSearch;

public abstract class SpecificationBase<T, D> : ISpecification<T> where T: class, IEntity
{
    protected D Data { get; }

    public SpecificationBase(D data)
    {
        Data = data;
    }

    public abstract Expression<Func<T, bool>> ToExpressions();
}