using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using System.Linq;

namespace SuperDuperMedAPP.Data
{
    public class DoctorRepository
    {
        private AppDbContext _db;

        public DoctorRepository() => _db = new AppDbContext();

        public DoctorRepository(AppDbContext dbContext) => _db = dbContext;

        public void AddDoctor(Doctor doctor)
        {
            _db.Doctors?.Add(doctor);
            _db.SaveChanges();
        }

        public Doctor? GetDoctorByUsername(string username)
        {
            return _db.Doctors.FirstOrDefault(x => x.Username.Equals(username));
        }

        public string? GetHashedPassword(string username)
        {
            return _db.Doctors.Where(x => x.Username.Equals(username)).Select(x => x.HashPassword).First();
        }
    }
}