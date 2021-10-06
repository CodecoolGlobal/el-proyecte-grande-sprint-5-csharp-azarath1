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

            var patients = new Patient[]
{
            new Patient{SocialSecurityNumber = 044033999, DoctorID = 1, Name="Mr. Instance Imre", DateOfBirth=DateTime.Parse("2005-09-01")},
            new Patient{SocialSecurityNumber = 044033919, DoctorID = 1, Name="Miss Exampli Gratia", DateOfBirth=DateTime.Parse("2002-09-01")},
            new Patient{SocialSecurityNumber = 044033929, DoctorID = 1, Name="Mr. Standard Arturo", DateOfBirth=DateTime.Parse("2003-09-01")}
};
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();


            var medicines = new Medicine[]
{
            new Medicine{ Name = "Medicine 1", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 2", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 3", Manufacturer = "Biotek Co.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 4", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 5", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 6", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 7", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 8", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 9", Manufacturer = "Pfaizer", DescriptionLink = ""},
            new Medicine{ Name = "Medicine 10", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = ""}

};
            foreach (Medicine m in medicines)
            {
                context.Medicines.Add(m);
            }
            context.SaveChanges();

            //TODO: fix medication init
            var medications = new Medication[]
            {
            new Medication{ Doses = 3, DoctorNotes = "Daily dose of 1 pill", Date = DateTime.Parse("2021-10-05"), MedicineID = 1, PatientID = 1 }
            };
            foreach (Medication me in medications)
            {
                context.Medications.Add(me);
            }
            context.SaveChanges();

        }
    }
}
