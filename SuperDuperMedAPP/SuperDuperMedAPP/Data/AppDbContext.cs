using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperDuperMedAPP.Models;
using System;
using System.IO;


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
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RegistrationNumber> RegistrationNumbers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<RegistrationNumber>().ToTable("RegistrationNumber");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .LogTo(Console.WriteLine
                        , new[] { DbLoggerCategory.Database.Command.Name }
                        , Microsoft.Extensions.Logging.LogLevel.Information);
            }
        }
    }
}