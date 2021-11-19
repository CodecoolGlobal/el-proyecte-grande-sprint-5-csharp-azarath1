using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Repositories;
using System.Threading.Tasks;

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
        [Route("medicine/{medicineId:int}")]
        [HttpGet]
        public async Task<ActionResult> GetMedicine([FromRoute] int medicineId, [FromRoute] int id)
        {
            var medicine = await _medicineRepository.GetMedicineById(medicineId);
            return Ok(medicine);
        }

        
        [Authorize(Roles = "doctor")]
        [Route("medicine/{id:int}")]
        [HttpGet]
        public async Task<ActionResult> GetAllMedicine([FromRoute] int id)
        {
            var meds = await _medicineRepository.GetAllMedicine();
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