using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SuperDuperMedAPP.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context, IAuthService service)
        {
            context.Database.EnsureCreated();

            // Look for any patients.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }
            var regNumbers = Enumerable
                .Range(0, 10)
                .Select(x => new RegistrationNumber
                {
                    RegNumber = new Random()
                        .Next(100000000, 999999999)
                        .ToString()
                })
                .ToList();
            foreach (var registrationNumber in regNumbers)
            {
                context.RegistrationNumbers.Add(registrationNumber);
            }
            context.SaveChanges();

            var socNumbers = Enumerable
                .Range(0, 10)
                .Select(x => new SocialSecurityNumber
                {
                    SocialSecurityNum = new Random()
                        .Next(100000000, 999999999)
                        .ToString()
                })
                .ToList();

            foreach (var socNumber in socNumbers)
            {
                context.SocialSecurityNumbers.Add(socNumber);
            }
            context.SaveChanges();

            var doctors = new Doctor[]
            {
            new Doctor{RegistrationNumber= regNumbers[0].RegNumber
                ,Name="Dr. Bubo"
                ,DateOfBirth=DateTime.Parse("2078-09-01")
                ,Email = "Dr@bubo@mail.hu"
                ,HashPassword = service.HashPassword("bubo")
                ,Username = "Bubo"
                ,Role = "doctor"
            }

            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }

            context.SaveChanges();

            var patients = new Patient[]
{
            new Patient{SocialSecurityNumber = socNumbers[0].SocialSecurityNum, DoctorID = 1, Name="Mr. Instance Imre", DateOfBirth=DateTime.Parse("2005-09-01"),HashPassword = service.HashPassword("Imre"),Username = "Imre",Role = "patient"},
            new Patient{SocialSecurityNumber = socNumbers[1].SocialSecurityNum, DoctorID = 1, Name="Miss Exampli Gratia", DateOfBirth=DateTime.Parse("2002-09-01"),HashPassword = service.HashPassword("Gratia"),Username = "Gratia",Role = "patient"},
            new Patient{SocialSecurityNumber = socNumbers[2].SocialSecurityNum, DoctorID = 1, Name="Mr. Standard Arturo", DateOfBirth=DateTime.Parse("2003-09-01"),HashPassword = service.HashPassword("Arturo"),Username = "Arturo",Role = "patient"}
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
            new Medication{ Name = "Xanax", Dose="2x1", DoctorNote="If you feel adverse effect please contact me!", Date=DateTime.Parse("2021-11-03"), Medicine=medic, PatientID=2 }
            };
            foreach (Medication me in medications)
            {
                context.Medications.Add(me);
            }
            context.SaveChanges();


        }
    }
}
