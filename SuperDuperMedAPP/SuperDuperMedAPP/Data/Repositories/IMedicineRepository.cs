using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicineRepository
    {
        Task AddMedicine(Medicine medicine);
        Task<List<Medicine>?> GetAllMedicine();
        Task<List<Medicine>?> GetMedicineByPageNumber(int pageNumber);
        Task<Medicine?> GetMedicineById(int medicineId);
        Task UpdateMedicine(Medicine medication);
        Task DeleteMedicine(int medicineId);
    }
}