using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _db;

        public MedicineRepository() => _db = new AppDbContext();

        public MedicineRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddMedicine(Medicine medicine)
        {
            _db.Medicine.Add(medicine);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Medicine>?> GetAllMedicine()
        {
            return await _db.Medicine.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Medicine>?> GetAllMedicineByPageNumber(int pageNumber)
        {
            return await _db.Medicine.OrderBy(x => x.Name).Skip(10 * pageNumber).Take(10).ToListAsync();
        }

        public async Task<Medicine?> GetMedicineById(int medicineId)
        {
            return await _db.Medicine.FirstOrDefaultAsync(x => x.MedicineID.Equals(medicineId));
        }

        public async Task UpdateMedicine(Medicine medication)
        {
            _db.Medicine.Update(medication);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMedicine(int medicineId)
        {
            var medicineToDelete = await _db.Medicine.FirstOrDefaultAsync(x => x.MedicineID == medicineId);
            _db.Medicine.Remove(medicineToDelete);
            await _db.SaveChangesAsync();
        }
    }
}