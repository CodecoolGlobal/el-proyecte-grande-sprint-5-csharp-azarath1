using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

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

        //to medication controller
        [Route("patient/{id:int}/medication/{pageNumber:int}")]
        public async Task<ActionResult> GetPatientMedication([FromRoute] int id, [FromRoute] int pageNumber)
        {
            var userMedication = await _medicationRepository.GetMedicationByPageNumber(id, pageNumber);
            if (userMedication == null)
            {
                return NoContent();
            }

            return Ok(userMedication);
        }

        [HttpPut]
        [Route("patient/{id:int}/edit-contacts")]
        public async Task<ActionResult> Editcontacts(UserContacts userContact, [FromRoute] int id)
        {
            await _services.UpdatePatientsContacts(userContact, id);
            return Ok();
        }

        [Route("patient/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            await _services.EditPassword(id, password);
            return Ok();
        }


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

        // doctorId From Body
        // from get to post method
        [HttpPost]
        [Route("doctors-patients/{pageNumber:int}")]
        public async Task<ActionResult> GetDoctorsPatients([FromBody] int doctorsId, [FromRoute] int pageNumber)
        {
            var allPatients = await _services.GetDoctorsPatients(doctorsId, pageNumber);

            if (allPatients == null)
            {
                return NotFound();
            }

            var response = allPatients.ToGetDoctorsPatientsDTOs();
            return Ok(response);
        }

        // doctorId From Body
        // patientId From Route
        [HttpPut]
        [Route("register-patient/{patientId:int}")]
        public async Task<ActionResult> ModifyDoctorId([FromBody] int doctorId, [FromRoute] int patientId)
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