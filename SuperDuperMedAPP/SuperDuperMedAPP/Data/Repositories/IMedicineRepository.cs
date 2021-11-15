using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicineRepository
    {
        Task AddMedication(Medicine medicine);
        Task<List<Medicine>?>  GetAllMedicine();
        Task<Medicine?>  GetMedicineById(int medicineId);
        Task UpdateMedicine(Medicine medication);
        Task DeleteMedicine(int medicineId);
    }
}