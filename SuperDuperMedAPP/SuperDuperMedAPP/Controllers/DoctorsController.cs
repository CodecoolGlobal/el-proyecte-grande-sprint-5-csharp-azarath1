﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;


namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsServices _services;

        public DoctorsController(IDoctorsServices services)
        {
            _services = services;
        }

        [Route("doctor/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInDoctorDetails([FromRoute] int id)
        {
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
            await _services.UpdateDoctorContacts(userContact, id);
            return Ok();
        }

        [Route("doctor/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            await _services.EditPassword(id, password);
            return Ok();
        }

        //To MedicationController
        [Route("doctor/{id:int}/patients-medications/{patientId:int}/{pageNumber:int}")]
        public async Task<ActionResult> GetPatientsMedicationAll([FromRoute] int id, [FromRoute] int patientId,
            [FromRoute] int pageNumber)
        {
            var medications = await _services.GetAllMedicationByPatientId(patientId, pageNumber);

            if (medications == null)
            {
                return NotFound();
            }

            var response = medications.ToGetPatientsMedicationAllDTO();
            return Ok(response);
        }
        // To MedicationController
        [Route("doctor/{id:int}/patients-medication/{medicationId:int}")]
        public async Task<ActionResult> GetPatientsMedicationSingle([FromRoute] int id, [FromRoute] int medicationId)
        {
            var medication = await _services.GetMedicationById(medicationId);

            if (medication == null)
            {
                return NotFound();
            }

            var response = medication.ToGetPatientsMedicationSingleDto();
            return Ok(response);
        }

        // To MedicationController
        [HttpPut]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-dosage")]
        public async Task<ActionResult> ModifyMedicationDosage([FromRoute] int id, [FromRoute] int medicationId,
            [FromBody] string newDosage)
        {
            var medication = await _services.GetMedicationById(medicationId);
            if (medication == null)
            {
                return NotFound();
            }

            await _services.EditMedicationDosage(medicationId, newDosage);
            return NoContent();
        }
        // To MedicationController
        [HttpPut]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-note")]
        public async Task<ActionResult> ModifyMedicationNote([FromRoute] int id, [FromRoute] int medicationId,
            [FromBody] string newNote)
        {
            var medication = await _services.GetMedicationById(medicationId);
            if (medication == null)
            {
                return NotFound();
            }

            await _services.EditMedicationNote(medicationId, newNote);
            return NoContent();
        }
        // To MedicationController
        [HttpPost]
        [Route("doctor/{id:int}/medication/add")]
        public async Task<ActionResult> AddMedication([FromRoute] int id, [FromBody] AddMedicationDTO medicationDto)
        {
            var medicine = await _services.GetMedicineById(medicationDto.MedicineID);
            if (medicine == null)
            {
                return NotFound();
            }

            var medication = medicationDto.ToMedication(medicine);
            await _services.AddMedication(medication);
            return NoContent();
        }
        // To MedicationController
        [HttpDelete]
        [Route("doctor/{id:int}/medication/{medId:int}/delete")]
        public async Task<ActionResult> DeleteMedication([FromRoute] int id, [FromRoute] int medId)
        {
            var medication = await _services.GetMedicationById(medId);
            if (medication == null)
            {
                return NotFound();
            }

            await _services.DeleteMedication(medId);
            return NotFound();
        }
    }
}