using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models.DTO;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private IMedicationService _services;

        public MedicationController(IMedicationService services)
        {
            _services = services;
        }

        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/medication/add")]
        [HttpPost]
        public async Task<ActionResult> AddMedication([FromBody] AddMedicationDTO medicationDto)
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


        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-dosage")]
        [HttpPut]
        public async Task<ActionResult> ModifyMedicationDosage([FromRoute] int medicationId,
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


        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/medication/{medicationId}/edit-note")]
        [HttpPut]
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


        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/medication/{medId:int}/delete")]
        [HttpDelete]
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

        //need?
        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/patients-medication/{medicationId:int}")]
        [HttpGet]
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

        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/patients-medications/{patientId:int}/{pageNumber:int}")]
        [HttpGet]
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

        [Authorize(Roles = "patient")]
        [Route("patient/{patientId:int}/medication/{pageNumber:int}")]
        [HttpGet]
        public async Task<ActionResult> GetPatientsMedication([FromRoute] int patientId, [FromRoute] int pageNumber)
        {
            var userMedication = await _services.GetAllMedicationByPatientId(patientId, pageNumber);
            if (userMedication == null)
            {
                return NoContent();
            }

            return Ok(userMedication.ToGetPatientsMedicationAllDTO());
        }
    }
}