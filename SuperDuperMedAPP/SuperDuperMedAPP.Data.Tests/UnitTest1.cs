using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanInsertDoctor()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("DataTestDb");

            using (var context = new AppDbContext(builder.Options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var doctorRepository = new DoctorRepository(context);
                var doctor = new Doctor()
                {
                    DateOfBirth = DateTime.Parse("2000.01.01"),
                    Email = "valami@valami.hu",
                    HashPassword = "asdasdadadwd",
                    Name = "Dr.Bubó",
                    PhoneNumber = "01201040",
                    Username = "B"
                };

                doctorRepository.AddDoctor(doctor);

                Assert.AreEqual(context.Doctors.First().Email, "valami@valami.hu");
            }
        }
    }
}