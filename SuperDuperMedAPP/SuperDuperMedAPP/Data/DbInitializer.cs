using SuperDuperMedAPP.Models;
using System;
using System.Linq;


namespace SuperDuperMedAPP.Data
    {
        public static class DbInitializer
        {
            public static void Initialize(AppDbContext context)
            {
                context.Database.EnsureCreated();

            // Look for any patients.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var doctors = new Doctor[]
            {
            new Doctor{Name="Dr. Bubo", DateOfBirth=DateTime.Parse("2078-09-01")}
            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }

            context.SaveChanges();


        }
    }
    }
