using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Data;

namespace SuperDuperMedAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorRepository _doctorRepository = new DoctorRepository();

        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterDoctor([FromBody] Doctor doctor)
        {
            
            _doctorRepository.AddDoctor(doctor);

            return Ok();
        }

        [Route("[action]")]
        public ActionResult GetLoggedInDoctor(string username)
        {
            var result = _doctorRepository.GetDoctorByUsername(username);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
            
        }
    }
}
