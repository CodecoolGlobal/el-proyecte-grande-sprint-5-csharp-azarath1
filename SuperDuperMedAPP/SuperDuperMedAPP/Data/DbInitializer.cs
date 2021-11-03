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
            new Doctor{RegistrationNumber=122312, Name="Dr. Bubo", DateOfBirth=DateTime.Parse("2078-09-01"),Email = "Dr@bubo@mail.hu",HashPassword = "bubo",Username = "Bubo"}

            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }

            context.SaveChanges();

            var patients = new Patient[]
{
            new Patient{SocialSecurityNumber = 044033999, DoctorID = 1, Name="Mr. Instance Imre", DateOfBirth=DateTime.Parse("2005-09-01"),HashPassword = "Imre",Username = "Imre"},
            new Patient{SocialSecurityNumber = 044033919, DoctorID = 1, Name="Miss Exampli Gratia", DateOfBirth=DateTime.Parse("2002-09-01"),HashPassword = "Gratia",Username = "Gratia"},
            new Patient{SocialSecurityNumber = 044033929, DoctorID = 1, Name="Mr. Standard Arturo", DateOfBirth=DateTime.Parse("2003-09-01"),HashPassword = "Arturo",Username = "Arturo"}
};
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();

            var medic = new Medicine { Name = "Medicine 8", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = "" };
            var medicines = new Medicine[]
{
            new Medicine{ Name = "Medicine 1", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 2", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 3", Manufacturer = "Biotek Co.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 4", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 5", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 6", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 7", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 9", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 10", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""}

};
            foreach (Medicine m in medicines)
            {
                context.Medicine.Add(m);
            }
            context.SaveChanges();

            
            var medications = new Medication[]
            {
            new Medication{ Name = "Medication daily", Dose="3", DoctorNote="Daily pill of 1", Date=DateTime.Parse("2021-11-03"), Medicine=medic, PatientID=2 }
            };
            foreach (Medication me in medications)
            {
                context.Medications.Add(me);
            }
            context.SaveChanges();

        }
    }
}
