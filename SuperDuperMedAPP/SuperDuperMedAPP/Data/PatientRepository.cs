﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data
{
    public class PatientRepository
    {
        private AppDbContext _db;

        public PatientRepository() => _db = new AppDbContext();
        public PatientRepository(AppDbContext dbContext) => _db = dbContext;


        public void AddPatient(Patient patient)
        {
            _db.Patients?.Add(patient);
            _db.SaveChanges();
        }

        public Patient? GetPatientByUsername(string username)
        {
            return _db.Patients?.FirstOrDefault(x => x.Username.Equals(username));
        }

        public string? GetHashedPassword(string username)
        {
            return _db.Patients.Where(x => x.Username.Equals(username)).Select(x => x.HashPassword).First();
        }
    }
}