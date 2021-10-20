using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private AppDbContext _db;

        public DoctorRepository() => _db = new AppDbContext();

        public DoctorRepository(AppDbContext dbContext) => _db = dbContext;

        public async Task AddDoctor(Doctor doctor)
        {
            _db.Doctors?.Add(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task<Doctor?> GetDoctorByUsername(string username)
        {
            return await _db.Doctors.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
        public async Task UpdateDoctor(Doctor doctor)
        {
            _db.Update(doctor);
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
            return await _db.Doctors.Where(x => x.Username.Equals(username)).Select(x => x.HashPassword).FirstOrDefaultAsync();
        }
    }
}