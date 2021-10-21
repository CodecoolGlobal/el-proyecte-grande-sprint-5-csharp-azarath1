﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientRepository _patientRepository;
        private IMedicationRepository _medicationRepository;
        private IMedicineRepository _medicineRepository;
        private const string SessionId = "_Id";

        public PatientsController(IPatientRepository patientRepository, IMedicationRepository medicationRepository,
            IMedicineRepository medicineRepository)
        {
            _patientRepository = patientRepository;
            _medicationRepository = medicationRepository;
            _medicineRepository = medicineRepository;
        }

        [HttpPost]
        [Route("patient/register")]
        public async Task<ActionResult> RegisterPatient(
            [FromBody] [Bind("SocialSecurityNumber,DoctorID,Name,DateOfBirth,Email,PhoneNumber,Username,HashPassword")]
            Patient patient)
        {
            if (await _patientRepository.GetPatientByUsername(patient.Username) != null)
            {
                return BadRequest("Username already in use!");
            }

            await _patientRepository.AddPatient(patient);

            HttpContext.Session.SetInt32(SessionId, patient.ID);


            //return Ok("Registration successful.");
            return Ok($"{patient.Name} has successfuly registered.");
        }

        [HttpPost]
        [Route("patient/login")]
        public async Task<ActionResult> Login([FromBody] SessionData data)
        {
            if (data.HashPassword.Equals("") || data.Username.Equals(""))
            {
                return Unauthorized("Please fill both username/password");
            }

            var patient = await _patientRepository.GetPatientById(data.ID);
            if (patient == null)
            {
                return Unauthorized("Password, or username doesn't match.");
            }

            HttpContext.Session.SetInt32(SessionId, data.ID);

            return Ok("Login successful.");
        }

        [Route("patient/{id}/logout")]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove(SessionId);
            return Ok("Successfully logged out.");
        }

        [Route("patient/{id}/details")]
        public async Task<ActionResult> GetLoggedInPatientDetails([FromRoute] int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
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

        [Route("patient/{id}/medication")]
        public async Task<ActionResult> GetPatientMedication([FromRoute] int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
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
        [Route("patient/{id}/edit-contacts")]
        public async Task<ActionResult> Editcontacts(UserContacts userContact, int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            await _patientRepository.UpdatePatientContacts(userContact, id);
            return Ok();
        }

        [Route("patient/{id}/medicine/{medicineID}")]
        public async Task<ActionResult> GetPatientsMedicine(int medicineID, int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            return Ok(await _medicineRepository.GetMedicineById(medicineID));
        }

        [Route("patient/{id}/password")]
        public async Task<ActionResult> EditPatient(int id, string password)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            await _patientRepository.EditPassword(id,password);
            return Ok();
        }
    }
}