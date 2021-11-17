using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Services
{
    public interface IPatientServices
    {
        Task<Patient?> GetPatientById(int patientId);
        Task EditDoctorId(int patientId, int newDoctorId);
        Task<List<Patient>?> GetAllPatients();

        Task<List<Patient>?> GetAllPatientsByPageNumber(int pageNumber);
        Task<List<Patient>?> GetDoctorsPatients(int doctorId, int pageNumber);
        Task UpdatePatientsContacts(UserContacts contacts, int id);
        Task EditPassword(int id, string password);
    }
}