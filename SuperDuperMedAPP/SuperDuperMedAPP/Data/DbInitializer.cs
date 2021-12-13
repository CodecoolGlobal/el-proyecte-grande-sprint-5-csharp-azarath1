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
                return; // DB has been seeded
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
                new Doctor
                {
                    RegistrationNumber = regNumbers[0].RegNumber, Name = "Dr. Bubo",
                    DateOfBirth = DateTime.Parse("2078-09-01"), Email = "Dr@bubo@mail.hu",
                    HashPassword = service.HashPassword("bubo"), Username = "Bubo", Role = "doctor"
                }
            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }

            context.SaveChanges();

            var patients = new Patient[]
            {
                new Patient
                {
                    SocialSecurityNumber = socNumbers[0].SocialSecurityNum, DoctorID = 1, Name = "Mr. Instance Imre",
                    DateOfBirth = DateTime.Parse("2005-09-01"), HashPassword = service.HashPassword("Imre"),
                    Username = "Imre", Role = "patient", Email = "imre@imre.hu"
                },
                new Patient
                {
                    SocialSecurityNumber = socNumbers[1].SocialSecurityNum, DoctorID = 1, Name = "Miss Exampli Gratia",
                    DateOfBirth = DateTime.Parse("2002-09-01"), HashPassword = service.HashPassword("Gratia"),
                    Username = "Gratia", Role = "patient", Email = "gratia@gratia.hu"
                },
                new Patient
                {
                    SocialSecurityNumber = socNumbers[2].SocialSecurityNum, DoctorID = 1, Name = "Mr. Standard Arturo",
                    DateOfBirth = DateTime.Parse("2003-09-01"), HashPassword = service.HashPassword("Arturo"),
                    Username = "Arturo", Role = "patient", Email = "arturo@arturo.hu"
                }
            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }

            context.SaveChanges();

            var medic = new Medicine { Name = "Medicine 8", Manufacturer = "Tova Gyógyszerkereskedelmi Zrt.", DescriptionLink = "" };
            var medicines = new Medicine[]
            {
                new Medicine
                {
                    Name = "ALGOPYRIN 500 mg", Manufacturer = "sanofi-aventis",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/algopyrin-500-mg/1581/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "FRONTIN 0,25 mg", Manufacturer = "EGIS",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/frontin-0-25-mg/4425/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "XANAX 0,25 mg", Manufacturer = "Pfizer",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/xanax-0-25-mg/3618/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "RITALIN 10 mg", Manufacturer = "Novartis Hungária",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/ritalin-10-mg/8399/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "ASPIRIN 500 mg", Manufacturer = "Bayer Hungária",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/aspirin-500-mg/1667/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "REXETIN 20 mg", Manufacturer = "Richter Gedeon",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/rexetin-20-mg/10810/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "ACC Long", Manufacturer = "Sandoz Hungária",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/acc-long-600/28482/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "NUROFEN FORTE", Manufacturer = "Reckitt Benckiser Healthcare",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/nurofen-forte-400/12737/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "ALGOFLEX FORTE", Manufacturer = "sanofi-aventis",
                    DescriptionLink =
                        "https://www.webbeteg.hu/gyogyszerkereso/algoflex-forte-filmtabletta/12881/betegtajekoztato"
                },

                new Medicine
                {
                    Name = "VIAGRA 100 mg", Manufacturer = "Pfizer UK",
                    DescriptionLink = "https://www.webbeteg.hu/gyogyszerkereso/viagra-100-mg/16711/betegtajekoztato"
                }
            };
            foreach (Medicine m in medicines)
            {
                context.Medicine.Add(m);
            }

            context.SaveChanges();


            var medications = new Medication[]
            {
                new Medication
                {
                    Name = "Xanax", Dose = "2x1", DoctorNote = "If you feel adverse effect please contact me!",
                    Date = DateTime.Parse("2021-11-03"), Medicine = medic, PatientID = 2
                }
            };
            foreach (Medication me in medications)
            {
                context.Medications.Add(me);
            }

            context.SaveChanges();
        }
    }
}