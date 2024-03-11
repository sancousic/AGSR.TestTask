using AGSR.Patients.Domain.Entities;

namespace AGSR.Patients.Domain.Repositories;

public interface IDomainRepository<T>
    where T : class, IEntity
{
    IQueryable<T> Query();

    Task<T> GetByIdAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<bool> DeleteAsync(Guid id);

    Task<T> UpdateAsync(T entity);
}