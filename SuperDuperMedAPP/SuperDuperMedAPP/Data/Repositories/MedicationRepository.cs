using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private AppDbContext _db;

        public MedicationRepository() => _db = new AppDbContext();

        public MedicationRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddMedication(Medication medication)
        {
            _db.Medications.Add(medication);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Medication>?> GetAllMedication(int patientId)
        {
            return await _db.Medications.Where(x => x.Patient.ID.Equals(patientId)).ToListAsync();
        }

        public async Task<Medication?> GetMedicationById(int patientId)
        {
            return await _db.Medications.FirstOrDefaultAsync(x => x.Patient.ID.Equals(patientId));
        }

        public async Task UpdateMedication(Medication medication)
        {
            _db.Medications.Update(medication);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMedication(int medicationId)
        {
            var medicationToDelete = await _db.Medications.FirstOrDefaultAsync(x => x.MedicationID == medicationId);
            _db.Medications.Remove(medicationToDelete);
            await _db.SaveChangesAsync();
        }
    }
}