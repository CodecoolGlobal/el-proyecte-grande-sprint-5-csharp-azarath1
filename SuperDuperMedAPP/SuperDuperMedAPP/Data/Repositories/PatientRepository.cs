using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class PatientRepository
    {
        private AppDbContext _db;

        public PatientRepository() => _db = new AppDbContext();
        public PatientRepository(AppDbContext dbContext) => _db = dbContext;


        public async Task AddPatient(Patient patient)
        {
            _db.Patients?.Add(patient);
            await _db.SaveChangesAsync();
        }

        public async Task<Patient>? GetPatientByUsername(string username)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.Username != null && x.Username.Equals(username));
        }

        public async Task<Patient>? GetPatientByDoctorId(int doctorId)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.DoctorID.Equals(doctorId));
        }

        public async Task<List<Patient>>? GetAllPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _db.Update(patient);
           await _db.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var PatientToDelete = _db.Patients.First(x => x.ID == id);
            _db.Patients.Remove(PatientToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<string?>  GetHashedPassword(string username)
        {
            return await _db.Patients.Where(x => x.Username.Equals(username)).Select(x => x.HashPassword).FirstOrDefaultAsync();
        }
    }
}