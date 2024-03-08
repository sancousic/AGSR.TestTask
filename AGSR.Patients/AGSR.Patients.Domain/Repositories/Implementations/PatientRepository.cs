using AGSR.Patients.Domain.Context;
using AGSR.Patients.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AGSR.Patients.Domain.Repositories.Implementations
{
    public class PatientRepository : DomainRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ConfigContext configContext)
            : base(configContext)
        {
        }

        protected override DbSet<Patient> Entities => configContext.Patients;

        public override IQueryable<Patient> Query() => configContext.Patients
            .Include(p => p.Name)
            .ThenInclude(n => n.GivenNames);

        public override async Task<Patient> CreateAsync(Patient entity)
        {
            Entities.Add(entity);
            await configContext.SaveChangesAsync();

            return entity;
        }

        public override async Task<Patient> GetByIdAsync(Guid id)
            => await Query().FirstOrDefaultAsync(x => x.Name.Id == id);

        public override async Task<Patient> UpdateAsync(Patient updateEntity)
        {
            var entity = await Query().FirstAsync(x => x.Name.Id == updateEntity.Name.Id);

            entity.BirthDate = updateEntity.BirthDate;
            entity.Gender = updateEntity.Gender;
            entity.Active = updateEntity.Active;
            entity.Name = updateEntity.Name;

            Entities.Update(entity);
            await configContext.SaveChangesAsync();

            return entity;
        }
    }
}
