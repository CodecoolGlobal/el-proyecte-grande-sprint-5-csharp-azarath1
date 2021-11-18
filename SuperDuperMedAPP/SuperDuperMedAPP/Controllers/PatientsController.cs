using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models.DTO;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientServices _services;

        public PatientsController(IPatientServices services)
        {
            _services = services;
        }


        [Authorize(Roles = "patient")]
        [Route("patient/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInPatientDetails([FromRoute] int id)
        {
            var result = await _services.GetPatientById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "patient")]
        [Route("patient/{id:int}/edit-contacts")]
        public async Task<ActionResult> EditContacts(UserContacts userContact, [FromRoute] int id)
        {
            await _services.UpdatePatientsContacts(userContact, id);
            return Ok();
        }

        [Authorize(Roles = "patient")]
        [Route("patient/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            await _services.EditPassword(id, password);
            return Ok();
        }

        //change in url
        [Authorize(Roles = "doctor")]
        [Route("all-patients/{pageNumber:int}")]
        public async Task<ActionResult> GetAllPatients([FromRoute] int pageNumber)
        {
            var allPatients = await _services.GetAllPatientsByPageNumber(pageNumber);

            if (allPatients == null)
            {
                return NotFound();
            }

            var response = allPatients.ToGetAllPatientsDTOs();
            return Ok(response);
        }

        [Authorize(Roles = "doctor")]
        [Route("doctor/{doctorsId:int}/patients/{pageNumber:int}")]
        public async Task<ActionResult> GetDoctorsPatients([FromRoute] int doctorsId, [FromRoute] int pageNumber)
        {
            var allPatients = await _services.GetDoctorsPatients(doctorsId, pageNumber);

            if (allPatients == null)
            {
                return NotFound();
            }

            var response = allPatients.ToGetDoctorsPatientsDTOs();
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "doctor")]
        [Route("doctor/{doctorId:int}/register-patient/{patientId:int}")]
        public async Task<ActionResult> ModifyDoctorId([FromRoute] int doctorId, [FromRoute] int patientId)
        {
            var patient = await _services.GetPatientById(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            await _services.EditDoctorId(patientId, doctorId);
            return NoContent();
        }
    }
}