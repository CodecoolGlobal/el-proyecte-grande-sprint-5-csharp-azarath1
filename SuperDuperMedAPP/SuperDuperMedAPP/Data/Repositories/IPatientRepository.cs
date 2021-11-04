using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IPatientRepository
    {
        Task AddPatient(Patient patient);
        Task<Patient?> GetPatientByUsername(string username);

        Task<Patient?> GetPatientById(int userid);
        Task<List<Patient>?> GetPatientsByDoctorId(int doctorId);
        Task<List<Patient>?> GetAllPatients();
        Task UpdatePatient(Patient patient);
        Task UpdatePatientContacts(UserContacts contacts,int id);
        Task DeletePatient(int id);
        Task<string?>  GetHashedPassword(int id);
        Task EditPassword(int patientId, string password);
        Task EditDoctorId(int PatientId, int newDoctorId);
    }
}