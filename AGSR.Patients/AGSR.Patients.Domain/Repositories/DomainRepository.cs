using AGSR.Patients.Domain.Context;
using AGSR.Patients.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AGSR.Patients.Domain.Repositories;

public abstract class DomainRepository<T> : IDomainRepository<T>
    where T : class, IEntity
{
    protected readonly ConfigContext configContext;

    protected DomainRepository(ConfigContext configContext)
    {
        this.configContext = configContext;
    }

    protected abstract DbSet<T> Entities { get; }

    public virtual IQueryable<T> Query() => Entities;

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity == null)
        {
            return false;
        }

        Entities.Remove(entity);
        var result = await configContext.SaveChangesAsync();

        return result > 0;
    }

    public abstract Task<T> GetByIdAsync(Guid id);

    public abstract Task<T> CreateAsync(T entity);
        
    public abstract Task<T> UpdateAsync(T entity);
}