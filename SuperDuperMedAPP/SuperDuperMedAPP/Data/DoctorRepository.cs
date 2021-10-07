using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data
{
    public class DoctorRepository
    {
        private AppDbContext _db;
        public DoctorRepository(AppDbContext db)
        {
            _db = db;
        }

        public DoctorRepository()
        {
            _db = new AppDbContext();
        }
        
        public void AddDoctor(Doctor doctor)
        {
            
            _db.Doctors?.Add(doctor);
            _db.SaveChanges();
        }
    }
}