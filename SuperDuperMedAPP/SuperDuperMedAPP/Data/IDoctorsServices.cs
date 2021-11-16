using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data
{
    public interface IDoctorsServices
    {
        Task AddDoctor(Doctor doctor);
        Task AddMedication(Medication medication);
        Task<Patient?> GetPatientById(int PatientId);
        Task<Doctor?> GetDoctorByUsername(string username);
        Task<Medicine?> GetMedicineById(int medId);
        Task<Doctor?> GetDoctorById(int id);
        Task<List<Doctor>?> GetAllDoctors();
        Task UpdateDoctor(Doctor doctor);
        Task UpdateDoctorContacts(UserContacts contacts, int id);
        Task DeleteDoctor(int id);
        Task DeleteMedication(int medId);
        Task<string?> GetHashedPassword(string username);
        Task EditPassword(int id, string password);
        Task EditDoctorId(int id, int newDoctorId);
        Task EditMedicationDosage(int medicationId, string newDosage);
        Task EditMedicationNote(int medicationId, string newNote);
        Task<List<Medicine>?> GetAllMedicine();
        Task<List<Patient>?> GetAllPatients();
        Task<List<Patient>?> GetAllPatientsByPageNumber(int pageNumber);
        Task<List<Patient>?> GetDoctorsPatients(int doctorId, int pageNumber);
        Task<List<Medication>?> GetAllMedicationByPatientId(int patientId, int pageNumber);
        Task<Medication?> GetMedicationById(int medicationId);
    }
}