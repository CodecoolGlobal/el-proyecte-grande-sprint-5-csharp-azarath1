using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicineRepository
    {
        Task AddMedication(Medicine medicine);
        Task<List<Medicine>?>  GetAllMedicine(int MedicineId);
        Task<Medicine?>  GetMedicineById(int MedicineId);
        Task UpdateMedicine(Medicine medication);
        Task DeleteMedicine(int medicineId);
    }
}