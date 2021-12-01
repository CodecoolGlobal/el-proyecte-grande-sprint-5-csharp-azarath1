using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly AppDbContext _db;

        public MedicationRepository() => _db = new AppDbContext();

        public MedicationRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddMedication(Medication medication)
        {
            _db.Medications.Add(medication);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Medication>?> GetMedicationByPageNumber(int patientId, int pageNumber)
        {
            return await _db.Medications
                .Where(x => x.PatientID.Equals(patientId))
                .Include("Medicine")
                .Skip(10 * pageNumber)
                .Take(10)
                .ToListAsync();
        }

        public async Task<Medication?> GetMedicationById(int medicationId)
        {
            return await _db.Medications.FirstOrDefaultAsync(x => x.MedicationID.Equals(medicationId));
        }

        public async Task DeleteMedication(int medicationId)
        {
            var medicationToDelete = await _db.Medications.FirstOrDefaultAsync(x => x.MedicationID == medicationId);
            _db.Medications.Remove(medicationToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task EditMedicationDosage(int medicationId, string? newDosage)
        {
            var medication = await _db.Medications.SingleOrDefaultAsync(x => x.MedicationID == medicationId);
            medication.Dose = newDosage;
            _db.Entry(medication).Property("Dose").IsModified = true;
            await _db.SaveChangesAsync();
        }

        public async Task EditMedicationNote(int medicationId, string newNote)
        {
            var medication = await _db.Medications.SingleOrDefaultAsync(x => x.MedicationID == medicationId);
            medication.DoctorNote = newNote;
            _db.Entry(medication).Property("DoctorNote").IsModified = true;
            await _db.SaveChangesAsync();
        }
    }
}