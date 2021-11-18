using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;
        private const string SessionId = "_Id";

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [Route("patient/{id:int}/medicine/{medicineId:int}")]
        [Route("doctor/{id:int}/medicine/{medicineId:int}")]
        public async Task<ActionResult> GetMedicine([FromRoute] int medicineId, [FromRoute] int id)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var medicine = await _medicineRepository.GetMedicineById(medicineId);
            return Ok(medicine);
        }

        [Authorize(Roles = "doctor")]
        [Route("medicine/{id:int}")]
        public async Task<ActionResult> GetAllMedicine([FromRoute] int id)
        {
            var meds = await _medicineRepository.GetAllMedicine();
            return Ok(meds);
        }


        [Route("doctor/{id:int}/medicine/{pageNumber:int}")]
        public async Task<ActionResult> GetMedicineByPage([FromRoute] int id, [FromRoute] int pageNumber)
        {
            if (id != HttpContext.Session.GetInt32(SessionId))
            {
                return Unauthorized();
            }

            var meds = await _medicineRepository.GetMedicineByPageNumber(pageNumber);
            return Ok(meds);
        }

        //[HttpPost]
        //[Route("medicine/add")]
        //public async Task<ActionResult> AddMedicine()
        //{
        //}

        //[HttpDelete]
        //[Route("medicine/delete")]
        //public async Task<ActionResult> DeleteMedicine()
        //{
        //}

        //[HttpPut]
        //[Route("medicine/update")]
        //public async Task<ActionResult> UpdateMedicine()
        //{
        //}

    }
}