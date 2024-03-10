using System.Data.Entity;
using AGSR.Patients.DataSearch.Models;
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
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(
            IPatientRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientModel> CreatePatient(PatientModel model)
        {
            var entity = _mapper.Map<Patient>(model);

            var result = await _repository.CreateAsync(entity);

            return _mapper.Map<PatientModel>(result);
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PatientModel> GetPatientById(Guid id)
        {
            var patient = await _repository.GetByIdAsync(id);

            return _mapper.Map<PatientModel>(patient);
        }

        public async Task<bool> IsPatientExists(Guid id)
        {
            return await _repository.Query().AnyAsync(x => x.Name.Id == id);
        }

        public async Task<IEnumerable<PatientModel>> SearchPatientsByDate(IEnumerable<DateSearchModel> dates)
        {
            var factory = new PeriodInfoFactory<PatientEntity>(patient =>
                new PeriodInfo(
                    new DateTimePoint(patient.BirthDate, true),
                    new DateTimePoint(patient.BirthDate, true)));

            var predicates = dates.Select(x => factory.GetBuilder(x.Prefix).BuildPredicate(x.Data));

            var predicateBuilder = PredicateBuilder.New<PatientEntity>();
            foreach (var predicate in predicates)
            {
                predicateBuilder.And(x => predicate(x));
            }


            return _mapper.Map<IEnumerable<PatientModel>>(_repository.Query().Where(predicateBuilder).ToList());
        }

        public async Task<PatientModel?> UpdatePatient(PatientModel patient)
        {
            var updated = await _repository.UpdateAsync(_mapper.Map<Patient>(patient));

            return _mapper.Map<PatientModel>(updated);
        }
    }
}
