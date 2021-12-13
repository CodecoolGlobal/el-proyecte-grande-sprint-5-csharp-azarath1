using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _db;

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

        public async Task<bool> SocNumberInUse(string socNumber)
        {
            return await _db.Patients.AnyAsync(x => x.SocialSecurityNumber.Equals(socNumber));
        }

        public Task<bool> IsUsernameUnique(string userName)
        {
            return _db.Patients.AnyAsync(patient => patient.Username.Equals(userName))
                .ContinueWith(result => !result.Result); ;
        }

        public Task<bool> IsEmailUnique(string email)
        {
           return _db.Patients.AnyAsync(patient => patient.Email.Equals(email))
               .ContinueWith(result => !result.Result);
        }

        public async Task<Patient?> GetPatientById(int userid)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.ID.Equals(userid));
        }

        public async Task<List<Patient>?> GetPatientsByDoctorId(int doctorId, int pageNumber)
        {
            return await _db.Patients
                .OrderBy(x => x.Name)
                .Where(x => x.DoctorID.Equals(doctorId))
                .Skip(10 * pageNumber)
                .Take(10)
                .ToListAsync();
        }

        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _db.Patients.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Patient>?> GetAllPatientsByPageNumber(int pageNumber)
        {
            return await _db.Patients.OrderBy(x => x.Name).Skip(10 * pageNumber).Take(10).ToListAsync();
        }

        public async Task UpdatePatientContacts(UserContacts contacts, int id)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(x => x.ID == id);
            if (contacts.Email != null)
            {
                patient.Email = contacts.Email;
                _db.Entry(patient).Property("Email").IsModified = true;
            }

            if (contacts.PhoneNumber != null)
            {
                patient.PhoneNumber = contacts.PhoneNumber;
                _db.Entry(patient).Property("PhoneNumber").IsModified = true;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patientToDelete = _db.Patients.First(x => x.ID == id);
            _db.Patients.Remove(patientToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task EditPassword(int patientId, string password)
        {
            var patient = await _db.Patients.SingleOrDefaultAsync(x => x.ID == patientId);
            patient.HashPassword = Crypto.HashPassword(password);
            _db.Entry(patient).Property("HashPassword").IsModified = true;
            await _db.SaveChangesAsync();
        }

        public async Task EditDoctorId(int patientId, int newDoctorId)
        {
            var patient = await _db.Patients.SingleOrDefaultAsync(x => x.ID == patientId);
            patient.DoctorID = newDoctorId;
            _db.Entry(patient).Property("DoctorID").IsModified = true;
            await _db.SaveChangesAsync();
        }
    }
}