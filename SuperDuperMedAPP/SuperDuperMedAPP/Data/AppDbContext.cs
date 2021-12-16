using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperDuperMedAPP.Models;
using System;
using System.IO;


namespace SuperDuperMedAPP.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration? Db { get; }

        public AppDbContext(DbContextOptions options, IConfiguration? configuration) : base(options)
        {
            Db = configuration;
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Doctor> Doctors { get; set; } = default!;
        public DbSet<Patient> Patients { get; set; } = default!;
        public DbSet<Medicine> Medicine { get; set; } = default!;
        public DbSet<Medication> Medications { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<RegistrationNumber> RegistrationNumbers { get; set; } = default!;
        public DbSet<SocialSecurityNumber> SocialSecurityNumbers { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Medication>().ToTable("Medication");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<RegistrationNumber>().ToTable("RegistrationNumber");
            modelBuilder.Entity<SocialSecurityNumber>().ToTable("SocialSecurityNumber");
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