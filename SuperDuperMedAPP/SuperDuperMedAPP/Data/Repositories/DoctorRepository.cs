using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _db;

        public DoctorRepository() => _db = new AppDbContext();

        public DoctorRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddDoctor(Doctor doctor)
        {
            _db.Doctors?.Add(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task<Doctor?> GetDoctorByUsername(string? username)
        {
            return await _db.Doctors.FirstOrDefaultAsync(x => x.Username != null && x.Username.Equals(username));
        }

        public async Task<Doctor?> GetDoctorById(int userid)
        {
            return await _db.Doctors.FirstOrDefaultAsync(x => x.ID.Equals(userid));
        }

        public async Task<bool> RegNumberInUse(string? regNumber)
        {
            return await _db.Doctors.AnyAsync(x => x.RegistrationNumber != null && x.RegistrationNumber.Equals(regNumber));
        }

        public async Task<List<Doctor>?> GetAllDoctors()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _db.Update(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateDoctorContacts(UserContacts contacts, int id)
        {
            var doctor = await _db.Doctors.FirstOrDefaultAsync(x => x.ID == id);
            if (contacts.Email != null)
            {
                doctor.Email = contacts.Email;
                _db.Entry(doctor).Property("Email").IsModified = true;
            }

            if (contacts.PhoneNumber != null)
            {
                doctor.PhoneNumber = contacts.PhoneNumber;
                _db.Entry(doctor).Property("PhoneNumber").IsModified = true;
            }

            await _db.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            var DoctorToDelete = await _db.Doctors.FirstAsync(x => x.ID == id);
            _db.Doctors.Remove(DoctorToDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<string?> GetHashedPassword(string username)
        {
            return await _db.Doctors.Where(x => x.Username != null && x.Username.Equals(username)).Select(x => x.HashPassword)
                .FirstOrDefaultAsync();
        }

        public async Task EditPassword(int id, string password)
        {
            var doctor = await _db.Doctors.FirstOrDefaultAsync(x => x.ID == id);
            doctor.HashPassword = Crypto.HashPassword(password);
            _db.Entry(doctor).Property("HashPassword").IsModified = true;
            await _db.SaveChangesAsync();
        }
    }
}