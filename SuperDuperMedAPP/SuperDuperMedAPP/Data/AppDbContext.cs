using System.IO;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;
using Microsoft.Extensions.Configuration;


namespace SuperDuperMedAPP.Data
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _db;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _db = configuration;
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Medicine>().ToTable("Medicine");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<User>().ToTable("User");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}