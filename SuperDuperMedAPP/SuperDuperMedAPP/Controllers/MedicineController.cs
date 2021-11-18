using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [Authorize(Roles = "doctor,patient")]
        [Route("patient/{id:int}/medicine/{medicineId:int}")]
        [Route("doctor/{id:int}/medicine/{medicineId:int}")]
        public async Task<ActionResult> GetMedicine([FromRoute] int medicineId, [FromRoute] int id)
        {
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


        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/medicine/{pageNumber:int}")]
        public async Task<ActionResult> GetMedicineByPage([FromRoute] int id, [FromRoute] int pageNumber)
        {
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