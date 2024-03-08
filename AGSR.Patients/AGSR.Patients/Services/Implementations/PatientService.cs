using AGSR.Patients.DateSearch;
using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Domain.Repositories;
using AGSR.Patients.Models;
using AutoMapper;
using LinqKit;
using PatientEntity = AGSR.Patients.Domain.Entities.Patient;

namespace AGSR.Patients.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repository;
        private readonly IPeriodInfoUtiluty periodInfoUtiluty;
        private readonly IPredicateBuilder<PatientEntity> predicateBuilder;
        protected readonly IMapper mapper;

        public PatientService(
            IPatientRepository repository,
            IMapper mapper,
            IPeriodInfoUtiluty periodInfoUtiluty,
            IPredicateBuilder<PatientEntity> predicateBuilder)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.periodInfoUtiluty = periodInfoUtiluty;
            this.predicateBuilder = predicateBuilder;
        }

        public async Task<PatientModel> CreatePatient(PatientModel model)
        {
            var entity = mapper.Map<Patient>(model);

            var result = await repository.CreateAsync(entity);

            return mapper.Map<PatientModel>(result);
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<PatientModel> GetPatientById(Guid id)
        {
            var patient = await repository.GetByIdAsync(id);

            return mapper.Map<PatientModel>(patient);
        }

        public async Task<bool> IsPatientExists(Guid id)
        {
            return repository.Query().Any(x => x.Name.Id == id);
        }

        public async Task<IEnumerable<PatientModel>> SearchPatientsByDate(IEnumerable<DateSearchModel> dates)
        {
            var infos = periodInfoUtiluty.GetPeriodInfos(dates).ToList();
            var predicate = predicateBuilder.BuildPredicate(infos);

            return mapper.Map<IEnumerable<PatientModel>>(repository.Query().Where(predicate).ToList());
        }

        public async Task<PatientModel?> UpdatePatient(PatientModel patient)
        {
            var updated = await repository.UpdateAsync(mapper.Map<Patient>(patient));

            return mapper.Map<PatientModel>(updated);
        }
    }
}
