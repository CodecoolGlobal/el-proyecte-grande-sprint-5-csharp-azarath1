using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private AppDbContext _db;

        public PatientRepository() => _db = new AppDbContext();
        public PatientRepository(AppDbContext dbContext) => _db = dbContext;


        public async Task AddPatient(Patient patient)
        {
            _db.Patients?.Add(patient);
            await _db.SaveChangesAsync();
        }

        public async Task<Patient?> GetPatientByUsername(string username)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }

        public async Task<Patient?> GetPatientById(int userid)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.ID.Equals(userid));
        }

        public async Task<List<Patient>?> GetPatientsByDoctorId(int doctorId)
        {
            return await _db.Patients.Where(x => x.DoctorID.Equals(doctorId)).ToListAsync();
        }

        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task UpdatePatient(Patient patient)
        {
            _db.Update(patient);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePatientContacts(UserContacts contacts, int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(x => x.ID == id);
            if (contacts.Email != null)
            {
                patient.Email = contacts.Email;
            }

            if (contacts.PhoneNumber != null)
            {
                patient.PhoneNumber = contacts.PhoneNumber;
            }

            _db.Entry(patient).Property("Email").IsModified = true;
            _db.Entry(patient).Property("PhoneNumber").IsModified = true;
            await _db.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patientToDelete = _db.Patients.First(x => x.ID == id);
            _db.Patients.Remove(patientToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<string?> GetHashedPassword(int id)
        {
            return await _db.Patients.Where(x => x.ID.Equals(id)).Select(x => x.HashPassword)
                .FirstOrDefaultAsync();
        }

        public async Task EditPassword(int patientId, string password)
        {
            var patient = await _db.Patients.SingleOrDefaultAsync(x => x.ID == patientId);
            patient.HashPassword = password;
            _db.Entry(patient).Property("HashPassword").IsModified = true;
            await _db.SaveChangesAsync();
        }

        public async Task EditDoctorId(int PatientId, int newDoctorId)
        {
            var patient = await _db.Patients.SingleOrDefaultAsync(x => x.ID == PatientId);
            patient.DoctorID = newDoctorId;
            _db.Entry(patient).Property("DoctorID").IsModified = true;
            await _db.SaveChangesAsync();
        }
    }
}