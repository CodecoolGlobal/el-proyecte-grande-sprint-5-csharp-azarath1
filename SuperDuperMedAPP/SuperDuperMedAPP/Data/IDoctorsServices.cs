using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data
{
    public interface IDoctorsServices
    {
        Task AddDoctor(Doctor doctor);
        Task<Doctor?> GetDoctorByUsername(string username);
        Task<Doctor?> GetDoctorById(int id);
        Task<List<Doctor>?> GetAllDoctors();
        Task UpdateDoctor(Doctor doctor);
        Task UpdateDoctorContacts(UserContacts contacts, int id);
        Task DeleteDoctor(int id);
        Task<string?> GetHashedPassword(string username);
        Task EditPassword(int id, string password);
        Task<List<Medicine>?> GetAllMedicine();
        Task<List<Patient>?> GetAllPatients();
        Task<List<Medication>?> GetAllMedicationByPatientId(int patientId);
    }
}