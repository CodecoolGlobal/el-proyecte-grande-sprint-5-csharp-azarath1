using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data
{
    public interface IDoctorsServices
    {
        Task AddDoctor(Doctor doctor);
        Task<Patient?> GetPatientById(int PatientId);
        Task<Doctor?> GetDoctorByUsername(string username);
        Task<Doctor?> GetDoctorById(int id);
        Task<List<Doctor>?> GetAllDoctors();
        Task UpdateDoctor(Doctor doctor);
        Task UpdateDoctorContacts(UserContacts contacts, int id);
        Task DeleteDoctor(int id);
        Task Deletemedication(int medId);
        Task<string?> GetHashedPassword(string username);
        Task EditPassword(int id, string password);
        Task EditDoctorId(int id, int newDoctorId);
        Task EditMedicationDosage(int medicationId, string newDosage);
        Task EditMedicationNote(int medicationId, string newNote);
        Task<List<Medicine>?> GetAllMedicine();
        Task<List<Patient>?> GetAllPatients();
        Task<List<Patient>?> GetDoctorsPatients(int doctorId);
        Task<List<Medication>?> GetAllMedicationByPatientId(int patientId);
        Task<Medication?> GetMedicationById(int medicationId);
    }
}