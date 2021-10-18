using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Data;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        PatientRepository _patientRepository = new PatientRepository();

        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterPatient([FromBody] Patient patient)
        {
            _patientRepository.AddPatient(patient);

            return Ok();
        }
        [Route("[action]")]
        public ActionResult GetLoggedInDoctor(string username)
        {
            var result = _patientRepository.GetPatientByUsername(username);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}
