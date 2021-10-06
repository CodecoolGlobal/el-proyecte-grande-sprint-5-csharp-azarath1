using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
namespace SuperDuperMedAPP.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Medicine> Medicines { get; set; }
            public DbSet<Medication> Medications { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Doctor>().ToTable("Doctor");
                modelBuilder.Entity<Patient>().ToTable("Patient");
                modelBuilder.Entity<Medicine>().ToTable("Medicine");
                modelBuilder.Entity<Medication>().ToTable("Medication");
            }
    }

}
