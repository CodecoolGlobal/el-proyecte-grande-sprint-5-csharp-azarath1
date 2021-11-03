using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IDoctorsServices _services;
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

            return Ok(doctor.ID);
            //return Ok($"{doctor.Name} has been successfuly registered.");
        }

        [HttpPost]
        [Route("doctor/login")]
        public async Task<ActionResult> Login([FromBody] SessionData data)
        {
            if (data.HashPassword.Equals("") || data.Username.Equals(""))
            {
                return Unauthorized("Please fill both username/password");
            }


            var all = await _services.GetAllDoctors();

            if (!all.Any(x => x.Username.Equals(data.Username)
                              && x.HashPassword.Equals(data.HashPassword)))
            {
                return Unauthorized("Password, or username doesn't match.");
            }

            var patient = await _services.GetDoctorByUsername(data.Username);
            HttpContext.Session.SetInt32(SessionId, patient.ID);
            Response.Cookies.Append("ID", patient.ID.ToString());
            return Ok("Login successful.");
        }

        [Route("doctor/{id:int}/logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove(SessionId);
            return Ok("Successfully logged out.");
        }

        [Route("doctor/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInPatientDetails([FromRoute] int id)
        {
            //patient dto
            if (id != HttpContext.Session.GetInt32(SessionId))
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
        public async Task<ActionResult> Editcontacts(UserContacts userContact, int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            await _services.UpdateDoctorContacts(userContact, id);
            return Ok();
        }

        [Route("doctor/{id:int}/password")]
        public async Task<ActionResult> EditPassword(int id, string password)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            await _services.EditPassword(id, password);
            return Ok();
        }

        [Route("doctor/{id:int}/all-medicine")]
        public async Task<ActionResult> GetAllMedicine(int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var medicine = await _services.GetAllMedicine();

            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        [Route("doctor/{id:int}/all-patients")]
        public async Task<ActionResult> GetAllPatients(int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var allPatients = await _services.GetAllPatients();

            if (allPatients == null)
            {
                return NotFound();
            }

            var patients = allPatients
                .Select(x => new
                {
                    x.Name,
                    DateOfBirth = x.DateOfBirth.ToLocalTime().ToShortDateString(),
                    x.SocialSecurityNumber,
                    x.Email,
                    x.PhoneNumber,
                    x.DoctorID
                }).ToList();

            return Ok(patients);
        }

        [Route("doctor/{id:int}/patients")]
        public async Task<ActionResult> GetDoctorsPatients(int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var allPatients = await _services.GetDoctorsPatients(id);

            if (allPatients == null)
            {
                return NotFound();
            }

            var patients = allPatients
                .Select(x => new
                {
                    x.Name,
                    DateOfBirth = x.DateOfBirth.ToLocalTime().ToShortDateString(),
                    x.SocialSecurityNumber,
                    x.Email,
                    x.PhoneNumber,
                    x.ID
                }).ToList();

            return Ok(patients);
        }

        [Route("doctor/{id:int}/patients-medications/{patientId:int}")]
        public async Task<ActionResult> GetPatientsMedications(int id, int patientId)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var medications = await _services.GetAllMedicationByPatientId(patientId);

            if (medications == null)
            {
                return NotFound();
            }

            var list = medications.Select(x => new
            {
                x.Name,
                x.Dose,
                Date = x.Date.ToLocalTime().ToShortDateString(),
                x.MedicationID,
            }).ToList();

            return Ok(medications);
        }

        [Route("doctor/{id:int}/patients-medication/{patientId:int}")]
        public async Task<ActionResult> GetPatientsMedication(int id, int patientId)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var medication = await _services.GetAllMedicationByPatientId(patientId);

            if (medication == null)
            {
                return NotFound();
            }

            var list = medication.Select(x => new
            {
                x.Name,
                x.Date,
                x.Dose,
                x.DoctorNote
            }).ToList();
            return Ok(list);
        }

        [HttpPut]
        [Route("doctor/{id:int}/register-patient")]
        public async Task<ActionResult> ModifyDoctorId(int id, [FromBody] int patientId)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
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
        public async Task<ActionResult> ModifyMedicationDosage(int id, int medicationId,
            [FromBody] string newDosage)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
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
        [Route("doctor/{id:int}/medication/{medicationId}/edit-dosage")]
        public async Task<ActionResult> ModifyMedicationNote(int id, [FromBody] int medicationId,
            [FromBody] string newNote)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
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
        public async Task<ActionResult> AddMedication(int id, [FromBody] AddMedicationDTO medicationDto)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var allmedicine = await _services.GetAllMedicine();
            var medicine = allmedicine.SingleOrDefault(x => x.MedicineID.Equals(medicationDto.MedicineID));
            if (medicine==null)
            {
                return NotFound();
            }

            var medication = new Medication
            {
                Name = medicationDto.Name,
                Dose = medicationDto.Dose,
                DoctorNote = medicationDto.DoctorNote,
                Date = new DateTime().ToLocalTime(),
                PatientID = medicationDto.PatientID,
                Medicine = medicine
            };
            return NoContent();
        }

        [HttpDelete]
        [Route("doctor/{id:int}/medication/{medId:int}/delete")]
        public async Task<ActionResult> DeleteMedication(int id, int medId)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }
            var allmedicine = await _services.GetAllMedicine();
            var medicine = allmedicine.SingleOrDefault(x => x.MedicineID.Equals(medId));
            if (medicine == null)
            {
                return NotFound();
            }

            await _services.Deletemedication(medId);
            return NotFound();

        }
    }
}