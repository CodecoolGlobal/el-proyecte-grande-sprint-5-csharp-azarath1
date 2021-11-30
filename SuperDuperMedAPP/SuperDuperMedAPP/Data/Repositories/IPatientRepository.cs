using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IPatientRepository
    {
        Task AddPatient(Patient patient);
        Task<Patient?> GetPatientByUsername(string username);
        Task<bool> SocNumberInUse(string socNumber);

        Task<Patient?> GetPatientById(int userid);
        Task<List<Patient>?> GetPatientsByDoctorId(int doctorId, int pageNumber);
        Task<List<Patient>?> GetAllPatients();
        Task<List<Patient>?> GetAllPatientsByPageNumber(int pageNumber);
        Task UpdatePatientContacts(UserContacts contacts, int id);
        Task DeletePatient(int id);
        Task EditPassword(int patientId, string password);
        Task EditDoctorId(int patientId, int newDoctorId);
    }
}