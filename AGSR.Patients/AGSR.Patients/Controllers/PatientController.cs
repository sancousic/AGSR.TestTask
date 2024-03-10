using AGSR.Patients.DataSearch.Models;
using AGSR.Patients.Models;
using AGSR.Patients.Requests;
using AGSR.Patients.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace AGSR.Patients.Controllers
{
    public class PatientController : ApiControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        
        }

        /// <summary>
        /// Retrieves a patient record based on the provided id.
        /// </summary>
        /// <param name="id">The Logical Id of a patient.</param>
        /// <returns>A single instance of pacient model with the content.</returns>
        /// <response code="200">Returns the instance of the searched patient.</response>
        /// <response code="404">If the patient with the same Id does not exists.</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientModel>> GetPatient(Guid id)
        {
            var patient = await patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        /// <summary>
        /// Allows searching for patients based on date.
        /// The date parameter format is yyyy-mm-ddThh:mm:ss.ssss[Z|(+|-)hh:mm] (the standard XML format).
        /// Any degree of precision can be provided, but it SHALL be populated from the left (e.g. can't specify a month without a year).
        /// Date searches can be controlled through the use of prefixes.
        /// </summary>
        /// <param name="request">The list of applied filters.</param>
        /// <remarks>
        /// Prefixes:
        ///     - eq: the resource value is equal to or fully contained by the parameter value;
        ///     - ne: the resource value is not equal to the parameter value;
        ///     - gt: the resource value is greater than the parameter value;
        ///     - lt: the resource value is less than the parameter value;
        ///     - ge: the resource value is greater or equal to the parameter value;
        ///     - le: the resource value is less or equal to the parameter value;
        ///     - sa: the resource value starts after the parameter value;
        ///     - eb: the resource value ends before the parameter value;
        ///     - ap: the resource value is approximately the same to the parameter value.
        ///           The value for the approximation 10% of the gap between now and the date.
        /// </remarks>
        /// <returns>the list of instances of pacient model with the content.</returns>
        /// <response code="200">Returns the list of instances of the searched patients.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PatientModel>>> SearchPatient(
            [FromQuery] SearchByDateRequest request,
            [FromServices] IValidator<SearchByDateRequest> validator)
            => await ValidateRequest(
                request,
                validator,
                 async (r) =>
                 {
                     var dateSearchModels = request.date.Select(x =>
                     {
                         var model = new DateSearchModel(x);
                         model.Init();

                         return model;
                     });

                     var patients = patientService.SearchPatientsByDate(dateSearchModels);

                     return patients;
                 }
            );

        /// <summary>
        /// Create a new patient.
        /// </summary>
        /// <param name="patient">The instance of <see cref="PatientModel"/> class.</param>
        /// <returns>A single instance of created pacient model with the content.</returns>
        /// <response code="200">Returns the instance of the created patient.</response>
        [HttpPost]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<PatientModel>> CreatePatient(PatientModel patient)
        {
            var result = await patientService.CreatePatient(patient);

            return Ok(result);
        }

        /// <summary>
        /// Updates patient.
        /// </summary>
        /// <param name="patient">The instance of <see cref="PatientModel"/> class.</param>
        /// <returns>A single instance of updated pacient model with the content.</returns>
        /// <response code="200">Returns the instance of the updated patient.</response>
        /// <response code="404">If the patient with the same Id does not exists.</response>
        [HttpPut]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientModel>> UpdatePatient(PatientModel patient)
        {
            var isPatientExists = await patientService.IsPatientExists(patient.Name.Id);

            if(!isPatientExists)
            {
                return NotFound();
            }

            var updatedPacient = await patientService.UpdatePatient(patient);

            return Ok(updatedPacient);
        }

        /// <summary>
        /// Deletes a patient record based on the provided id.
        /// </summary>
        /// <param name="id">The Logical Id of a patient.</param>
        /// <response code="200">Returns the instance of the searched patient.</response>
        /// <response code="404">If the patient with the same Id does not exists.</response>
        [HttpDelete]
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
