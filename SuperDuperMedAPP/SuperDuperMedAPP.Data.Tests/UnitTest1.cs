using System;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Tests
{
    public class PatietnsTests
    {
        private PatientRepository _pRepository;
        private AppDbContext _context;
        private Patient _patient;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("DataTestDb");
            _context = new AppDbContext(builder.Options);

            _context.Database.EnsureDeletedAsync();
            _context.Database.EnsureCreatedAsync();
            _pRepository = new PatientRepository(_context);

            _patient = new Patient()
            {
                DateOfBirth = DateTime.Parse("1991.01.01"),
                SocialSecurityNumber = "204-001-301",
                Email = "valami@valami.hu",
                HashPassword = "asdasd",
                Name = "Mr.Nobody",
                PhoneNumber = "01201040",
                Username = "MrN",
                DoctorID = 1
            };
            var patient = new Patient()
            {
                DateOfBirth = DateTime.Parse("1992.01.01"),
                SocialSecurityNumber = "010-101-101",
                Email = "I@am.hu",
                HashPassword = "asd",
                Name = "Mr.Me",
                PhoneNumber = "01010101",
                Username = "Me",
                DoctorID = 2
            };
            _context.Patients.Add(_patient);
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        [Test]
        public async Task Should_AddPatient_When_MethodIsCalled()
        {
            var patient = new Patient()
            {
                DateOfBirth = DateTime.Parse("1995.01.01"),
                SocialSecurityNumber = "111-222-333",
                Email = "i@mbatman.hu",
                HashPassword = Crypto.HashPassword("asd"),
                Name = "Batman",
                PhoneNumber = "06200120104",
                Username = "Bman",
                DoctorID = 1
            };

            await _pRepository.AddPatient(patient);
            Assert.That(_context.Patients.Any(patient1 =>patient1.Username.Equals("Bman")), Is.True);
        }

        [Test]
        public async Task Should_GetPatientByUsername_When_MethodIsCalled()
        {
            var theOne = await _pRepository.GetPatientByUsername("MrN");
            Assert.That(theOne.Name, Is.EqualTo("Mr.Nobody"));
        }

        [Test]
        public async Task Should_GetPatientById_When_MethodIsCalled()
        {
            var theOne = await _pRepository.GetPatientById(1);
            Assert.That(theOne.Name, Is.EqualTo("Mr.Nobody"));
        }

        [Test]
        public async Task Should_GetPatientByDoctorId_When_MethodIsCalled()
        {
            var theOne = await _pRepository.GetPatientsByDoctorId(1, 0);
            Assert.That(theOne.First().Name, Is.EqualTo("Mr.Nobody"));
        }

        [Test]
        public async Task Should_GetAllPatients_When_MethodIsCalled()
        {
            var allPatients = await _pRepository.GetAllPatients();
            Assert.That(allPatients.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Should_UpdateEmail_When_MethodIsCalled()
        {
            var contacts = new UserContacts
            {
                Email = "I@am.awsome.com",
                PhoneNumber = null
            };

            await _pRepository.UpdatePatientContacts(contacts, 1);
            Assert.That(_patient.Email, Is.EqualTo("I@am.awsome.com"));
        }

        [Test]
        public async Task Should_UpdatePhoneNumber_When_MethodIsCalled()
        {
            var contacts = new UserContacts
            {
                Email = null,
                PhoneNumber = "06206669999"
            };
            await _pRepository.UpdatePatientContacts(contacts, 1);
            Assert.That(_patient.PhoneNumber, Is.EqualTo("06206669999"));
        }

        [Test]
        public async Task Should_UpdateContacts_When_MethodIsCalled()
        {
            var contacts = new UserContacts
            {
                Email = "I@am.awsome.com",
                PhoneNumber = "06206669999"
            };
            await _pRepository.UpdatePatientContacts(contacts, 1);
            Assert.That(_patient.Email, Is.EqualTo("I@am.awsome.com"));
            Assert.That(_patient.PhoneNumber, Is.EqualTo("06206669999"));
        }

        [Test]
        public async Task Should_DeletePatient_When_MethodIsCalled()
        {
            await _pRepository.DeletePatient(1);
            Assert.That(await _pRepository.GetPatientById(1), Is.Null);
        }

        [Test]
        public async Task Should_EditPassword_When_MethodIsCalled()
        {
            await _pRepository.EditPassword(1, "Pass");
            Assert.That(Crypto.VerifyHashedPassword(_patient.HashPassword,"Password"), Is.False);
        }
    }
}