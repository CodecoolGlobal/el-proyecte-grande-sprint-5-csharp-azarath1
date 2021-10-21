using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private AppDbContext _db;

        public MedicineRepository() => _db = new AppDbContext();

        public MedicineRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddMedication(Medicine medicine)
        {
            _db.Medicines.Add(medicine);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Medicine>?>  GetAllMedicine(int MedicineId)
        {
            return await _db.Medicines.Where(x => x.MedicineID.Equals(MedicineId)).ToListAsync();
        }

        public async Task<Medicine?>  GetMedicineById(int MedicineId)
        {
            return await _db.Medicines.FirstOrDefaultAsync(x => x.MedicineID.Equals(MedicineId));
        }

        public async Task UpdateMedicine(Medicine medication)
        {
            _db.Medicines.Update(medication);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMedicine(int medicineId)
        {
            var MedicineToDelete = await _db.Medicines.FirstOrDefaultAsync(x => x.MedicineID == medicineId);
            _db.Medicines.Remove(MedicineToDelete);
           await _db.SaveChangesAsync();
        }
    }
}