using AGSR.Patients.DataSearch.Models;
using AGSR.Patients.DateSearch;
using AGSR.Patients.Models;

namespace AGSR.Patients.Services
{
    public interface IPatientService
    {
        Task<PatientModel> CreatePatient(PatientModel model);

        Task<PatientModel> GetPatientById(Guid id);

        Task<bool> DeletePatient(Guid id);

        Task<PatientModel?> UpdatePatient(PatientModel patient);

        Task<bool> IsPatientExists(Guid id);

        Task<IEnumerable<PatientModel>> SearchPatientsByDate(IEnumerable<DateSearchModel> dates);
    }
}