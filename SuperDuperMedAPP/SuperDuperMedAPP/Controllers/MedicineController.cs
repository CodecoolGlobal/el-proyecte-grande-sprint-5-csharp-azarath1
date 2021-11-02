using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private IMedicineRepository _medicineRepository;
        private const string SessionId = "_Id";

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [Route("patient/{id}/medicine/{medicineID}")]
        [Route("doctor/{id}/medicine/{medicineID}")]
        public async Task<ActionResult> GetPatientsMedicine(int medicineID, int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            return Ok(await _medicineRepository.GetMedicineById(medicineID));
        }
    }
}