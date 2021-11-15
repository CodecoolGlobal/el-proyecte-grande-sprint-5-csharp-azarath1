using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicationRepository _medicationRepository;
        private const string SessionId = "_Id";

        public PatientsController(IPatientRepository patientRepository, IMedicationRepository medicationRepository)
        {
            _patientRepository = patientRepository;
            _medicationRepository = medicationRepository;
        }

        [HttpPost]
        [Route("patient/register")]
        public async Task<ActionResult> RegisterPatient([FromBody] Patient patient)
        {
            var result = await _patientRepository.GetPatientByUsername(patient.Username);

            if (result != null)
            {
                return BadRequest("Username already in use!");
            }

            await _patientRepository.AddPatient(patient);

            HttpContext.Session.SetInt32(SessionId, patient.ID);

            Response.Cookies.Append("ID", patient.ID.ToString());
            Response.Cookies.Append("user", "patient");

            return Ok("Registration successful.");

        }

        [HttpPost]
        [Route("patient/login")]
        public async Task<ActionResult> Login([FromBody] SessionData data)
        {
            if (data.HashPassword.Equals("") || data.Username.Equals(""))
            {
                return Unauthorized("Please fill both username/password");
            }

            var all = await _patientRepository.GetAllPatients();

            if (all != null && !all.Any(x => x.Username.Equals(data.Username)
                                             && x.HashPassword.Equals(data.HashPassword)))
            {
                return Unauthorized("Password, or username doesn't match.");
            }

            var patient = await _patientRepository.GetPatientByUsername(data.Username);
            if (patient == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32(SessionId, patient.ID);
            Response.Cookies.Append("user", "patient");
            Response.Cookies.Append("ID", patient.ID.ToString());
            Response.Cookies.Append("user", "patient");
            return Ok("Login successful.");

        }

        [Route("patient/{id}/logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("ID");
            Response.Cookies.Delete("user");
            return Ok("Successfully logged out.");
        }

        [Route("patient/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInPatientDetails([FromRoute] int id)
        {
            var sessionID = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionID)
            {
                return Unauthorized();
            }

            var result = await _patientRepository.GetPatientById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("patient/{id:int}/medication")]
        public async Task<ActionResult> GetPatientMedication([FromRoute] int id)
        {
            var sessionID = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionID)
            {
                return Unauthorized();
            }

            var userMedication = await _medicationRepository.GetAllMedication(id);
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
            var sessionID = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionID)
            {
                return Unauthorized();
            }

            await _patientRepository.UpdatePatientContacts(userContact, id);
            return Ok();
        }

        [Route("patient/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            var sessionID = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionID)
            {
                return Unauthorized();
            }

            await _patientRepository.EditPassword(id, password);
            return Ok();
        }
    }
}