using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;


namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsServices _services;
        private const string SessionId = "_Id";

        public DoctorsController(IDoctorsServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("doctor/register")]
        public async Task<ActionResult> RegisterDoctor(
            [FromBody] Doctor doctor)
        {
            var result = await _services.GetDoctorByUsername(doctor.Username);

            if (result != null)
            {
                return BadRequest("Username already in use!");
            }

            await _services.AddDoctor(doctor);

            HttpContext.Session.SetInt32(SessionId, doctor.ID);

            Response.Cookies.Append("ID", doctor.ID.ToString());
            Response.Cookies.Append("user", "doctor");


            return Ok($"{doctor.Name} has been successfuly registered.");
        }

        [HttpPost]
        [Route("doctor/login")]
        public async Task<ActionResult> Login([FromBody] LoginData data)
        {
            if (data.Password.Equals("") || data.Username.Equals(""))
            {
                return Unauthorized("Please fill both username/password");
            }


            var all = await _services.GetAllDoctors();
            if (all == null)
            {
                return NotFound();
            }

            if (!all.Any(x => x.Username.Equals(data.Username)
                              && x.HashPassword.Equals(data.Password)))
            {
                return Unauthorized("Password, or username doesn't match.");
            }

            var doctor = await _services.GetDoctorByUsername(data.Username);
            if (doctor == null)
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32(SessionId, doctor.ID);
            Response.Cookies.Append("ID", doctor.ID.ToString());
            Response.Cookies.Append("user", "doctor");

            return Ok("Login successful.");
        }

        [Route("doctor/{id:int}/logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove(SessionId);
            Response.Cookies.Delete("ID");
            Response.Cookies.Delete("user");
            return Ok("Successfully logged out.");
        }

        [Route("doctor/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInDoctorDetails([FromRoute] int id)
        {
            //patient dto
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var result = await _services.GetDoctorById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("doctor/{id:int}/edit-contacts")]
        public async Task<ActionResult> EditContacts(UserContacts userContact, [FromRoute] int id)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            await _services.UpdateDoctorContacts(userContact, id);
            return Ok();
        }

        [Route("doctor/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            await _services.EditPassword(id, password);
            return Ok();
        }

        [Route("doctor/{id:int}/all-patients/{pageNumber:int}")]
        public async Task<ActionResult> GetAllPatients([FromRoute] int id, [FromRoute] int pageNumber)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var allPatients = await _services.GetAllPatientsByPageNumber(pageNumber);

            if (allPatients == null)
            {
                return NotFound();
            }

            var response = allPatients.ToGetAllPatientsDTOs();
            return Ok(response);
        }

        [Route("doctor/{id:int}/patients/{pageNumber:int}")]
        public async Task<ActionResult> GetDoctorsPatients([FromRoute] int id, [FromRoute] int pageNumber)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var allPatients = await _services.GetDoctorsPatients(id, pageNumber);

            if (allPatients == null)
            {
                return NotFound();
            }

            var response = allPatients.ToGetDoctorsPatientsDTOs();
            return Ok(response);
        }

        [Route("doctor/{id:int}/patients-medications/{patientId:int}/{pageNumber:int}")]
        public async Task<ActionResult> GetPatientsMedicationAll([FromRoute] int id, [FromRoute] int patientId,
            [FromRoute] int pageNumber)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var medications = await _services.GetAllMedicationByPatientId(patientId, pageNumber);

            if (medications == null)
            {
                return NotFound();
            }

            var response = medications.ToGetPatientsMedicationAllDTO();
            return Ok(response);
        }

        [Route("doctor/{id:int}/patients-medication/{medicationId:int}")]
        public async Task<ActionResult> GetPatientsMedicationSingle([FromRoute] int id, [FromRoute] int medicationId)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var medication = await _services.GetMedicationById(medicationId);

            if (medication == null)
            {
                return NotFound();
            }

            var response = medication.ToGetPatientsMedicationSingleDto();
            return Ok(response);
        }

        [HttpPut]
        [Route("doctor/{id:int}/register-patient")]
        public async Task<ActionResult> ModifyDoctorId([FromRoute] int id, [FromBody] int patientId)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var patient = await _services.GetPatientById(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            await _services.EditDoctorId(patientId, id);
            return NoContent();
        }

        [HttpPut]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-dosage")]
        public async Task<ActionResult> ModifyMedicationDosage([FromRoute] int id, [FromRoute] int medicationId,
            [FromBody] string newDosage)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var medication = await _services.GetMedicationById(medicationId);
            if (medication == null)
            {
                return NotFound();
            }

            await _services.EditMedicationDosage(medicationId, newDosage);
            return NoContent();
        }

        [HttpPut]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-note")]
        public async Task<ActionResult> ModifyMedicationNote([FromRoute] int id, [FromRoute] int medicationId,
            [FromBody] string newNote)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var medication = await _services.GetMedicationById(medicationId);
            if (medication == null)
            {
                return NotFound();
            }

            await _services.EditMedicationNote(medicationId, newNote);
            return NoContent();
        }

        [HttpPost]
        [Route("doctor/{id:int}/medication/add")]
        public async Task<ActionResult> AddMedication([FromRoute] int id, [FromBody] AddMedicationDTO medicationDto)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }


            var medicine = await _services.GetMedicineById(medicationDto.MedicineID);
            if (medicine == null)
            {
                return NotFound();
            }

            var medication = medicationDto.ToMedication(medicine);
            await _services.AddMedication(medication);
            return NoContent();
        }

        [HttpDelete]
        [Route("doctor/{id:int}/medication/{medId:int}/delete")]
        public async Task<ActionResult> DeleteMedication([FromRoute] int id, [FromRoute] int medId)
        {
            var sessionId = HttpContext.Session.GetInt32(SessionId);
            if (id != sessionId)
            {
                return Unauthorized();
            }

            var allMedicine = await _services.GetAllMedicine();
            var medicine = allMedicine?.SingleOrDefault(x => x.MedicineID.Equals(medId));
            if (medicine == null)
            {
                return NotFound();
            }

            await _services.DeleteMedication(medId);
            return NotFound();
        }
    }
}