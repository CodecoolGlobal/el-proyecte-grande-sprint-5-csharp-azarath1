﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IPatientRepository
    {
        Task AddPatient(Patient patient);
        Task<Patient>? GetPatientByUsername(string username);
        Task<Patient>? GetPatientByDoctorId(int doctorId);
        Task<List<Patient>>? GetAllPatients();
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int id);
        Task<string?>  GetHashedPassword(string username);
    }
}