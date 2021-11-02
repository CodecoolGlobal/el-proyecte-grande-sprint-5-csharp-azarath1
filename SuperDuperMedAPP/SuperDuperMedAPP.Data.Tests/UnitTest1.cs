using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;

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
                SocialSecurityNumber = 204001301,
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
                SocialSecurityNumber = 01010101,
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
                DateOfBirth = DateTime.Parse("1991.01.01"),
                SocialSecurityNumber = 204001301,
                Email = "valami@valami.hu",
                HashPassword = "asdasd",
                Name = "Mr.Nobody",
                PhoneNumber = "01201040",
                Username = "MrN",
                DoctorID = 1
            };

            await _pRepository.AddPatient(patient);
            Assert.That(_context.Patients.First().Email, Is.EqualTo("valami@valami.hu"));
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
            var theOne = await _pRepository.GetPatientByDoctorId(1);
            Assert.That(theOne.Name, Is.EqualTo("Mr.Nobody"));
        }

        [Test]
        public async Task Should_GetAllPatients_When_MethodIsCalled()
        {
            var allPatients = await _pRepository.GetAllPatients();
            Assert.That(allPatients.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Should_UpdatesPatient_When_MethodIsCalled()
        {
            var patient = new Patient()
            {
                DateOfBirth = DateTime.Parse("1991.01.01"),
                SocialSecurityNumber = 204001301,
                Email = "valami@valami.hu",
                HashPassword = "asdasd",
                Name = "Mr.Nobody",
                PhoneNumber = "01201040",
                Username = "MrN",
                DoctorID = 1
            };

            await _pRepository.UpdatePatient(patient);

            Assert.That(_patient.DateOfBirth.ToString(), Is.EqualTo("1991. 01. 01. 0:00:00"));
            Assert.That(_patient.SocialSecurityNumber, Is.EqualTo(204001301));
            Assert.That(_patient.Email, Is.EqualTo("valami@valami.hu"));
            Assert.That(_patient.HashPassword, Is.EqualTo("asdasd"));
            Assert.That(_patient.Name, Is.EqualTo("Mr.Nobody"));
            Assert.That(_patient.PhoneNumber, Is.EqualTo("01201040"));
            Assert.That(_patient.Username, Is.EqualTo("MrN"));
            Assert.That(_patient.DoctorID, Is.EqualTo(1));
        }

        [Test]
        public async Task Should_UpdateEmail_When_MethodIsCalled()
        {
            var contacts = new UserContacts();
            contacts.Email = "I@am.awsome.com";
            contacts.PhoneNumber = null;

            await _pRepository.UpdatePatientContacts(contacts, 1);
            Assert.That(_patient.Email, Is.EqualTo("I@am.awsome.com"));
        }

        [Test]
        public async Task Should_UpdatePhoneNumber_When_MethodIsCalled()
        {
            var contacts = new UserContacts();
            contacts.Email = null;
            contacts.PhoneNumber = "06206669999";

            await _pRepository.UpdatePatientContacts(contacts, 1);
            Assert.That(_patient.PhoneNumber, Is.EqualTo("06206669999"));
        }

        [Test]
        public async Task Should_UpdateContacts_When_MethodIsCalled()
        {
            var contacts = new UserContacts();
            contacts.Email = "I@am.awsome.com";
            contacts.PhoneNumber = "06206669999";

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
        public async Task Should_ReturnPassword_When_MethodIsCalled()
        {
            var pass = await _pRepository.GetHashedPassword(1);
            Assert.That(pass, Is.EqualTo("asdasd"));
        }

        [Test]
        public async Task Should_EditPassword_When_MethodIsCalled()
        {
            await _pRepository.EditPassword(1, "asd");
            Assert.That(_patient.HashPassword, Is.EqualTo("asd"));
        }
    }
}