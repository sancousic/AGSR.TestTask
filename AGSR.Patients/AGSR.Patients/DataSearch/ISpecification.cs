using System.Linq.Expressions;
using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.DateSearch;

public interface ISpecification<T> where T: class, IEntity
{
    Expression<Func<T, bool>> ToExpressions();
}