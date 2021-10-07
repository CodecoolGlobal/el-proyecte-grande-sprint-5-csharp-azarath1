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
        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterDoctor([FromBody] Doctor doctor)
        {
            var doctorRepository = new DoctorRepository();
            doctorRepository.AddDoctor(doctor);

            return Ok();
        }
    }
}
