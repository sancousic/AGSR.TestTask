using AGSR.Patients.DateSearch;
using AGSR.Patients.Models;
using AGSR.Patients.Requests;
using AGSR.Patients.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AGSR.Patients.Controllers
{
    public class PatientController : ApiControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult<PatientModel>> CreatePatient(PatientModel patient)
        {
            var result = await patientService.CreatePatient(patient);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PatientModel>> GetPatient(Guid id)
        {
            var patient = await patientService.GetPatientById(id);

            if(patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PatientModel>>> SearchPatient([FromQuery]SearchByDateRequest request, [FromServices] IValidator<SearchByDateRequest> validator)
            => await ValidateRequest(
                request,
                validator,
                 async (r) =>
                 {
                     var dateSearchModels = request.date.Select(x => new DateSearchModel(x));

                     var patients = await patientService.SearchPatientsByDate(dateSearchModels);

                     return patients;
                 }
            );

        [HttpPut]
        public async Task<ActionResult<PatientModel>> UpdatePatient(PatientModel patient)
        {
            var isPacientExists = await patientService.IsPatientExists(patient.Name.Id);

            if(!isPacientExists) 
            {
                return NotFound();
            }

            var updatedPacient = await patientService.UpdatePatient(patient);

            return Ok(updatedPacient);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(Guid id)
        {
            var result = await patientService.DeletePatient(id);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
