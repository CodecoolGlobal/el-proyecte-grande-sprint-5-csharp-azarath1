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

            var medicine = await _medicineRepository.GetMedicineById(medicineID);
            return Ok(medicine);
        }

        [Route("doctor/{id}/medicine")]
        public async Task<ActionResult> GetAllMedicine(int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var meds = await _medicineRepository.GetAllMedicine();
            return Ok(meds);
        }
    }
}